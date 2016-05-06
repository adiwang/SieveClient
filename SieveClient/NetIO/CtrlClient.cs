using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace NetIO
{
    class CtrlClient
    {
        TcpClient _client;
        NetworkStream _streamToCtrl;

        // 连接至控制器
        public bool Connect(string ip, short port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(ip, port);
            }
            catch
            {
                return false;
            }
            _streamToCtrl = _client.GetStream();    // 获取连接至控制器的流
            return true;
        }

        // 向控制器发送控制信息
        public bool Send(byte[] msg)
        {
            try
            {
                lock (_streamToCtrl)
                {
                    _streamToCtrl.Write(msg, 0, msg.Length);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
