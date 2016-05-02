using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    // 一个数据包的内存结构
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NetPacket
    {
        public Int32 version;               // 封包的版本号                                   :0-3
        public byte head;                   // 包头                                           :4
        public byte tail;                   // 包尾                                           :5
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.U1)]
        public byte[] check;                // data部分的校验值-16字节md5                      :6-21
        public Int32 type;                  // 包数据的类型                                    :22-25
        public Int32 datalen;               // 包数据的内容长度，不包括此包结构和包头尾          :26-29
        public Int32 reserve;               // 保留字段，暂不使用                              :30-33
    }

    public class NetBase
    {
        // 把32位的int保存在byte[4]中。先转为网络字节序，然后int的最高位保存为byte[idx],最低位保存为byte[idx+3]
        public static bool Int32ToByte(Int32 intNum, byte[] byteNum, int idx)
        {
            long network_byteorder = IPAddress.HostToNetworkOrder(intNum);
            byteNum[idx] = (byte)((network_byteorder & 0xff000000) >> 24);
            byteNum[idx + 1] = (byte)((network_byteorder & 0x00ff0000) >> 16);
            byteNum[idx + 2] = (byte)((network_byteorder & 0x0000ff00) >> 8);
            byteNum[idx + 3] = (byte)(network_byteorder & 0x000000ff);
            return true;
        }

        // 把byte[4]转换为32位的int，int的最高位保存为byte[idx]，最低位保存为byte[idx+3]，然后转换为主机字节序
        public static bool ByteToInt32(byte[] byteNum, int idx, ref Int32 intNum)
        {
            intNum = (byteNum[idx] << 24) + (byteNum[idx + 1] << 16) + (byteNum[idx + 2] << 8) + byteNum[idx + 3];
            intNum = IPAddress.NetworkToHostOrder(intNum);
            return true;
        }

        // 把64位的int保存在byte[8]中。先转为网络字节序，然后int的最高位保存为byte[idx],最低位保存为byte[idx+7]
        public static bool Int64ToByte(Int64 intNum, byte[] byteNum, int idx)
        {

            byte[] temp = System.BitConverter.GetBytes(intNum);
            // c#在windows平台下默认是小端表示，网络字节序是大端, 因此将数组reverse一下会换成网络字节序, 但是我们最终又会把它换成小端表示
            //Array.Reverse(temp);
            Array.Copy(temp, byteNum, 8);
            /*
            // 用这种方式传int64的值过来会抛异常
            UInt64 network_byteorder = Convert.ToUInt64(IPAddress.HostToNetworkOrder(intNum));
            byteNum[idx]     = (byte)((network_byteorder & 0xff00000000000000) >> 56);
            byteNum[idx + 1] = (byte)((network_byteorder & 0x00ff000000000000) >> 48);
            byteNum[idx + 2] = (byte)((network_byteorder & 0x0000ff0000000000) >> 40);
            byteNum[idx + 3] = (byte)((network_byteorder & 0x000000ff00000000) >> 32);
            byteNum[idx + 4] = (byte)((network_byteorder & 0x00000000ff000000) >> 24);
            byteNum[idx + 5] = (byte)((network_byteorder & 0x0000000000ff0000) >> 16);
            byteNum[idx + 6] = (byte)((network_byteorder & 0x000000000000ff00) >> 8);
            byteNum[idx + 7] = (byte)((network_byteorder & 0x00000000000000ff));
            */
            return true;
        }

        // 把byte[8]转换为64位的int，int的最高位保存为byte[idx]，最低位保存为byte[idx+7]，然后转换为主机字节序
        public static bool ByteToInt64(byte[] byteNum, int idx, ref Int64 intNum)
        {
            intNum = (byteNum[idx] << 56) + (byteNum[idx + 1] << 48) + (byteNum[idx + 2] << 40) + (byteNum[idx + 3] << 32) +
                     (byteNum[idx + 4] << 24) + (byteNum[idx + 5] << 16) + (byteNum[idx + 6] << 8) + byteNum[idx + 7];
            //intNum = IPAddress.NetworkToHostOrder(intNum);
            intNum = System.BitConverter.ToInt64(byteNum, 0);
            return true;
        }

        public static int NET_PACKAGE_HEADLEN = Marshal.SizeOf(new NetPacket());

        // 将NetPacket转换为byte数据，byteData必须有38字节以上空间
        public static bool NetPacketToByte(ref NetPacket package, byte[] byteData, int idx)
        {
            if (!Int32ToByte(package.version, byteData, idx))
            {
                return false;
            }
            byteData[idx + 4] = package.head;
            byteData[idx + 5] = package.tail;
            Array.Copy(package.check, 0, byteData, idx + 6, 16);
            if (!Int32ToByte(package.type, byteData, idx + 22))
            {
                return false;
            }
            if (!Int32ToByte(package.datalen, byteData, idx + 26))
            {
                return false;
            }
            if (!Int32ToByte(package.reserve, byteData, idx + 30))
            {
                return false;
            }
            return true;
        }

        // 将byte数组转换为NetPackage数据
        public static bool ByteToNetPacket(byte[] byteData, int idx, ref NetPacket package)
        {
            if (!ByteToInt32(byteData, idx, ref package.version))
            {
                return false;
            }
            package.head = byteData[idx + 4];
            package.tail = byteData[idx + 5];
            Array.Copy(byteData, 6, package.check, 0, 16);
            if (!ByteToInt32(byteData, idx + 22, ref package.type))
            {
                return false;
            }
            if (!ByteToInt32(byteData, idx + 26, ref package.datalen))
            {
                return false;
            }
            if (!ByteToInt32(byteData, idx + 30, ref package.reserve))
            {
                return false;
            }
            return true;
        }

    }   // end of NetBase
}   // end of namespace
