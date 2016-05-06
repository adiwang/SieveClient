using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    public delegate void FullPacketHandle(ref NetPacket packetHead, byte[] packetData, object userData);

    class PacketSync
    {
        private enum ParseType
        {
            PARSE_HEAD,                                             // 解析出head
            PARSE_NOTHING,                                          // 未解析出head
        }
        private const int BufferSize = 10240;

        private byte _head;                                         // 封包头部字节
        private byte _tail;                                         // 封包尾部字节
        private ParseType _parseType;                               // 分析类型
        private int _get_data_len;                                  // 得到的真实数据部分(当前有效载荷部分)的长度
        private int _head_pos;                                      // 封包头部字节的位置
        private byte[] _thread_readdata;                            // 保存接收到的数据
        private int _readdata_size;                                 // _thread_readdata缓冲区的大小
        private List<byte> _thread_packetdata;                      // 保存得到的真实数据部分(当前有效载荷部分)的数据
        private int _true_packet_len;                               // 标识了当前_thread_readdata中有效数据的长度
        public NetPacket _packet;                                   // 解析出的帧头
        public event FullPacketHandle FullPacketEvent;              // 解析出一个完整包的回调
        private object UserData;                                    // 回调时传给用户的数据

        public PacketSync(byte head, byte tail)
        {
            _head = head;
            _tail = tail;
            _parseType = ParseType.PARSE_NOTHING;
            _get_data_len = 0;
            _head_pos = -1;
            _thread_readdata = new byte[BufferSize];
            _readdata_size = BufferSize;
            _thread_packetdata = new List<byte>();
            _true_packet_len = 0;
            _packet = new NetPacket();
        }

        public void SetUserData(object userdata)
        {
            UserData = userdata;
        }

        public void RecvData(byte[] data, int len)
        {
            int iret = 0;           // 本次接收到的数据中读取到的位置
            while (iret < len || _true_packet_len >= NetBase.NET_PACKAGE_HEADLEN + 2)
            {
                // 数据未读取完或者已读取的数据足够分析则根据parsetype进入循环进行不同的处理
                if (_parseType == ParseType.PARSE_NOTHING)
                {
                    // 未解析出head
                    if (_readdata_size - _true_packet_len >= len - iret)
                    {
                        // 缓冲区剩余空间大于剩余要读取数据的长度, 直接拷贝数据
                        Array.Copy(data, iret, _thread_readdata, _true_packet_len, len - iret);
                        _true_packet_len += len - iret;
                        iret = len;
                    }
                    else
                    {
                        // 缓冲区剩余空间不够了，此时只拷贝剩余空间大小的数据
                        Array.Copy(data, iret, _thread_readdata, _true_packet_len, _readdata_size - _true_packet_len);
                        iret += _readdata_size - _true_packet_len;
                        _true_packet_len = _readdata_size;
                    }
                    _head_pos = Array.IndexOf(_thread_readdata, _head, 0, _true_packet_len);
                    if (_head_pos == -1)
                    {
                        // 找不到包头, 标记_thread_readdata中的数据无效
                        _true_packet_len = 0;
                        continue;
                    }
                    if (_true_packet_len - _head_pos - 1 < NetBase.NET_PACKAGE_HEADLEN)
                    {
                        // 得到的数据长度不足够解析包头，先将数据缓存
                        if (_head_pos != 0)
                        {
                            Array.Copy(_thread_readdata, _head_pos, _thread_readdata, 0, _true_packet_len - _head_pos);
                            _true_packet_len -= _head_pos;
                        }
                        continue;
                    }
                    // 得帧头
                    int frame_head_pos = _head_pos + 1;
                    // 解析帧头数据
                    NetBase.ByteToNetPacket(_thread_readdata, frame_head_pos, ref _packet);
                    // 校验帧头数据是否合法
                    if (_packet.head != this._head || _packet.tail != this._tail || _packet.datalen < 0)
                    {
                        // 帧头数据不合法(数据内容长度允许为0)
                        Array.Copy(_thread_readdata, frame_head_pos, _thread_readdata, 0, _true_packet_len - frame_head_pos);
                        _true_packet_len -= frame_head_pos;
                        continue;
                    }
                    _parseType = ParseType.PARSE_HEAD;
                    // 得帧数据
                    // _true_packet_len - frame_head_pos - NetBase.NET_PACKAGE_HEADLEN 为本次获得的数据长度
                    // _packet.datalen + 1为 数据真正的大小 + 1字节的包尾
                    _get_data_len = Math.Min(_true_packet_len - frame_head_pos - NetBase.NET_PACKAGE_HEADLEN, _packet.datalen + 1);
                    int data_pos = frame_head_pos + NetBase.NET_PACKAGE_HEADLEN;
                    if (_get_data_len > 0)
                    {
                        // 拷贝数据部分到packetdata中
                        _thread_packetdata.Clear();
                        for (int i = 0; i < _get_data_len; ++i)
                        {
                            _thread_packetdata.Add(_thread_readdata[data_pos + i]);
                        }
                    }
                }   // end of if _parseType == PARSE_NOTHING

                if (_get_data_len < _packet.datalen + 1)
                {
                    // 接收的数据不够
                    if (_get_data_len + (len - iret) < _packet.datalen + 1)
                    {
                        // 本次剩余的数据都加上也不够，拷贝剩余数据，等待下一轮的读取
                        for (int i = 0; i < len - iret; ++i)
                        {
                            _thread_packetdata.Add(_thread_readdata[iret + i]);
                        }
                        _get_data_len += len - iret;
                        iret = len;
                        return;
                    }
                    else
                    {
                        // 剩余数据加上后足够完整的数据, 拷贝数据部分剩余长度的数据
                        for (int i = 0; i < _packet.datalen + 1 - _get_data_len; ++i)
                        {
                            _thread_packetdata.Add(_thread_readdata[iret + i]);
                            iret += _packet.datalen + 1 - _get_data_len;
                            _get_data_len = _packet.datalen + 1;
                        }
                    }
                }

                // 走到这里意味着解析出一个完整的封包，校验包尾字节是否合法
                if (_thread_packetdata[_packet.datalen] != this._tail)
                {
                    // 包尾数据不合法
                    if (_true_packet_len - _head_pos - 1 - NetBase.NET_PACKAGE_HEADLEN >= _packet.datalen + 1)
                    {
                        // 数据足够
                        Array.Copy(_thread_readdata, _head_pos + 1, _thread_readdata, 0, _true_packet_len - _head_pos - 1);
                        _true_packet_len -= _head_pos + 1;
                    }
                    else
                    {
                        // 数据不足
                        if (_readdata_size < NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 1)
                        {
                            // 缓冲区空间不够大，重新分配缓冲区
                            byte[] new_readdata = new byte[NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 1];
                            Array.Copy(_thread_readdata, 0, new_readdata, 0, _readdata_size);
                            _thread_readdata = new_readdata;
                            _readdata_size = NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 1;
                        }
                        // 先拷贝帧头
                        Array.Copy(_thread_readdata, _head_pos + 1, _thread_readdata, 0, NetBase.NET_PACKAGE_HEADLEN);
                        _true_packet_len = NetBase.NET_PACKAGE_HEADLEN;
                        // 再拷贝真实数据部分
                        for (int i = 0; i < _packet.datalen + 1; ++i)
                        {
                            _thread_readdata[_true_packet_len + i] = _thread_packetdata[i];
                        }
                        _true_packet_len += _packet.datalen + 1;
                    }
                    _parseType = ParseType.PARSE_NOTHING;
                    continue;
                }
                // TODO: 校验md5 (暂不校验check值)

                if (_true_packet_len - _head_pos - 1 - NetBase.NET_PACKAGE_HEADLEN >= _packet.datalen + 1)
                {
                    // thread_data数据足够,将本包尾后的数据拷贝
                    Array.Copy(_thread_readdata, _head_pos + NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 2, _thread_readdata, 0,
                               _true_packet_len - (_head_pos + NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 2));
                    _true_packet_len -= _head_pos + NetBase.NET_PACKAGE_HEADLEN + _packet.datalen + 2;
                }
                else
                {
                    // 从新开始读取数据
                    _true_packet_len = 0;
                }
                // 回调帧数据给用户
                if (FullPacketEvent != null)
                {
                    FullPacketEvent(ref _packet, _thread_packetdata.ToArray(), UserData);
                }
                _parseType = ParseType.PARSE_NOTHING;
            }   // end of while loop
        }
    }   // end of PacketSync

    public class PacketBuilder
    {
        public static byte[] Build(ref NetPacket packetHead, byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            ms.WriteByte(packetHead.head);
            byte[] packetHeadBytes = new byte[NetBase.NET_PACKAGE_HEADLEN];
            NetBase.NetPacketToByte(ref packetHead, packetHeadBytes, 0);
            ms.Write(packetHeadBytes, 0, NetBase.NET_PACKAGE_HEADLEN);
            ms.Write(data, 0, data.Length);
            ms.WriteByte(packetHead.tail);
            byte[] result = ms.ToArray();
            ms.Close();
            return result;
        }

    }   // end of PacketBuilder
}   // end of namespace
