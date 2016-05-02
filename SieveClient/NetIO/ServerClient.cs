using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    public class ServerClient
    {
        private const int BufferSize = 8192;                            // 缓冲区大小
        private byte[] _buffer;                                         // 缓冲区
        private TcpClient _client;
        private NetworkStream _streamToServer;
        private PacketSync _packet_handler;                             // 收到数据后对封包进行解包的handler
        private byte _head;                                             // 封包头部字节
        private byte _tail;                                             // 封包尾部字节
        private Dictionary<int/*protocol id*/, Protocol> _protocols;    // 协议map

        public ServerClient(byte head, byte tail)
        {
            _head = head;
            _tail = tail;
            _client = new TcpClient();
            _buffer = new byte[BufferSize];
            _packet_handler = new PacketSync(head, tail);
            _packet_handler.SetUserData(this);
            _packet_handler.FullPacketEvent += OnGetFullPacket;
            _protocols = new Dictionary<int, Protocol>();
        }

        public bool Connect(string host, short port)
        {
            try
            {
                _client.Connect(host, port);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect Exception|{0}", ex.Message);
                return false;
            }
            _streamToServer = _client.GetStream();
            // 调用BeginRead开始接收数据
            lock (_streamToServer)
            {
                AsyncCallback callback = new AsyncCallback(ReadComplete);
                _streamToServer.BeginRead(_buffer, 0, BufferSize, callback, null);
            }
            return true;
        }

        public void Send(byte[] msg)
        {
            // 发送
            try
            {
                _streamToServer.Write(msg, 0, msg.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Exception|{0}", ex.Message);
            }
        }

        private void ReadComplete(IAsyncResult ar)
        {
            //读取完成时的回调方法
            int bytesRead = 0;
            try
            {
                lock (_streamToServer)
                {
                    bytesRead = _streamToServer.EndRead(ar);
                }
                if (bytesRead == 0) throw new Exception("读取到0字节");
                // 处理收到的数据
                _packet_handler.RecvData(_buffer, bytesRead);
                // 清空缓存，避免脏读
                Array.Clear(_buffer, 0, _buffer.Length);
                // 再次调用BeginRead(), 完成时调用自身，形成无限循环
                lock (_streamToServer)
                {
                    AsyncCallback callback = new AsyncCallback(ReadComplete);
                    _streamToServer.BeginRead(_buffer, 0, BufferSize, callback, null);
                }
            }   // end of try
            catch (Exception ex)
            {
                Console.WriteLine("Read Exception|{0}", ex.Message);
            }   // end of catch
        }

        public void AddProtocol(int protoId, Protocol proto)
        {
            _protocols.Add(protoId, proto);
        }

        public void RemoveProtocol(int protoId)
        {
            _protocols.Remove(protoId);
        }

        public Protocol GetProtocol(int protoId)
        {
            if (_protocols.ContainsKey(protoId))
                return _protocols[protoId];
            return null;
        }

        public static void OnGetFullPacket(ref NetPacket packetHead, byte[] packetData, object userdata)
        {
            ServerClient client = (ServerClient)userdata;
            int protoId = 0;
            byte[] protoData;
            int dataSize = 0;
            if (packetHead.type == 1)
            {
                // 采用protobuf解析协议
                MemoryStream ms = new MemoryStream(packetData);
                netmessage.CProto proto = new netmessage.CProto();
                proto = ProtoBuf.Serializer.Deserialize<netmessage.CProto>(ms);
                ms.Close();
                protoId = proto.id;
                protoData = System.Text.Encoding.Default.GetBytes(proto.body);
                dataSize = protoData.Length;
            }
            else if (packetHead.type == 2)
            {
                // 手动解析协议
                // 前4个字节是协议id, 后面是序列化的协议内容
                NetBase.ByteToInt32(packetData, 0, ref protoId);
                dataSize = packetHead.datalen - 4;
                protoData = new byte[dataSize];
                Array.Copy(packetData, 4, protoData, 0, dataSize);
            }
            else
            {
                // 无效协议
                return;
            }
            if (protoId > 0)
            {
                Protocol protoHandle = client.GetProtocol(protoId);
                if (protoHandle != null)
                {
                    protoHandle.Clone().Process(protoData, dataSize, userdata);
                }
            }
        }

    }   // end of ServerClient
}   // end of namespace
