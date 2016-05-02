using NetIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace NetIOTest
{
    
    
    /// <summary>
    ///这是 ServerClientTest 的测试类，旨在
    ///包含所有 ServerClientTest 单元测试
    ///</summary>
    [TestClass()]
    public class ServerClientTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///AddProtocol 的测试
        ///</summary>
        [TestMethod()]
        public void AddProtocolTest()
        {
            byte head = 0xf0;
            byte tail = 0x0f;
            ServerClient target = new ServerClient(head, tail);
            int protoId = 1;
            CProtocol1 cproto1 = new CProtocol1();
            target.AddProtocol(protoId, cproto1);

            Protocol new_proto = target.GetProtocol(protoId).Clone();
            Assert.IsInstanceOfType(new_proto, typeof(CProtocol1));
        }

        /// <summary>
        ///GetProtocol 的测试
        ///</summary>
        [TestMethod()]
        public void GetProtocolTest()
        {
            byte head = 0xf0;
            byte tail = 0x0f;
            ServerClient target = new ServerClient(head, tail);
            int protoId = 1;
            CProtocol1 cproto1 = new CProtocol1();
            target.AddProtocol(protoId, cproto1);

            Protocol new_proto = target.GetProtocol(protoId).Clone();
            Assert.IsInstanceOfType(new_proto, typeof(CProtocol1));
        }

        /// <summary>
        ///RemoveProtocol 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveProtocolTest()
        {
            byte head = 0xf0;
            byte tail = 0x0f;
            ServerClient target = new ServerClient(head, tail);
            int protoId = 1;
            CProtocol1 cproto1 = new CProtocol1();
            target.AddProtocol(protoId, cproto1);
            Protocol new_proto = target.GetProtocol(protoId).Clone();
            Assert.IsInstanceOfType(new_proto, typeof(CProtocol1));
            target.RemoveProtocol(protoId);
            new_proto = target.GetProtocol(protoId);
            Assert.IsNull(new_proto);
        }

        /// <summary>
        ///OnGetFullPacket 的测试
        ///</summary>
        [TestMethod()]
        public void OnGetFullPacketTest()
        {
            byte head = 0xf0;
            byte tail = 0x0f;
            ServerClient target = new ServerClient(head, tail);
            int protoId = 1;
            CProtocol1 cproto1 = new CProtocol1();
            target.AddProtocol(protoId, cproto1);

            netmessage.CP1 cp1 = new netmessage.CP1();
            cp1.a = 32;
            cp1.b = 64;
            cp1.c = "this is full packet test";
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.CP1>(ms, cp1);
            netmessage.CProto cproto = new netmessage.CProto();
            cproto.id = 1;
            cproto.body = System.Text.Encoding.Default.GetString(ms.ToArray());
            ms.Seek(0, SeekOrigin.Begin);
            ProtoBuf.Serializer.Serialize<netmessage.CProto>(ms, cproto);
            byte[] data = ms.ToArray();
            ms.Close();

            NetPacket packetHead = new NetPacket();
            packetHead.head = 0xf0;
            packetHead.tail = 0x0f;
            packetHead.type = 1;
            packetHead.datalen = data.Length;
            ServerClient.OnGetFullPacket(ref packetHead, data, target);
            Assert.IsTrue(true);
        }
    }
}
