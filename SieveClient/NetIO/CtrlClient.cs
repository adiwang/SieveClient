using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace NetIO
{
    class CtrlClient
    {
        TcpClient _client;
        NetworkStream _streamToCtrl;
        string ip;
        short port;
        // 检查网络状态线程
        Thread checkStateThread;

        // 连接至控制器
        public bool Connect(string ip, short port)
        {
            this.ip = ip;
            this.port = port;
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

        public void CreateCheckStateThread()
        {
            checkStateThread = new Thread(new ThreadStart(CheckState));
            checkStateThread.IsBackground = true;
            checkStateThread.Start();
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

        public void Close()
        {
            _streamToCtrl.Dispose();
            _client.Close();
        }

        private void CheckState()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (!_client.Connected)
                {
                    try
                    {
                        _streamToCtrl.Dispose();
                        _client.Close();
                        _client = new TcpClient();
                        _client.Connect(this.ip, this.port);
                        _streamToCtrl = _client.GetStream();
                    }
                    catch
                    {
                    }
                }
            }
        }
        
    }
}
