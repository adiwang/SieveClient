using NetIO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetIOTest
{
    
    
    /// <summary>
    ///这是 NetBaseTest 的测试类，旨在
    ///包含所有 NetBaseTest 单元测试
    ///</summary>
    [TestClass()]
    public class NetBaseTest
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
        ///ByteToInt32 的测试
        ///</summary>
        [TestMethod()]
        public void ByteToInt32Test()
        {
            byte[] byteNum = new byte[4];
            byteNum[0] = 0x7A;
            byteNum[1] = 0x56;
            byteNum[2] = 0x34;
            byteNum[3] = 0x12;
            int intNum = 0;
            bool result = NetBase.ByteToInt32(byteNum, 0, ref intNum);
            Assert.AreEqual(0x1234567A, intNum);
        }

        /// <summary>
        ///ByteToInt64 的测试
        ///</summary>
        [TestMethod()]
        public void ByteToInt64Test()
        {
            byte[] byteNum = new byte[8];
            byteNum[0] = 0xEF;
            byteNum[1] = 0xCD;
            byteNum[2] = 0xAB;
            byteNum[3] = 0x89;
            byteNum[4] = 0x67;
            byteNum[5] = 0x45;
            byteNum[6] = 0x23;
            byteNum[7] = 0x01;
            Int64 intNum = 0;
            bool result = NetBase.ByteToInt64(byteNum, 0, ref intNum);
            Assert.AreEqual(0x0123456789ABCDEF, intNum);
        }

        /// <summary>
        ///Int32ToByte 的测试
        ///</summary>
        [TestMethod()]
        public void Int32ToByteTest()
        {
            int intNum = 0x1234567A;
            byte[] byteNum = new byte[4];

            bool result = NetBase.Int32ToByte(intNum, byteNum, 0);
            Assert.AreEqual(0x7A, byteNum[0]);
            Assert.AreEqual(0x56, byteNum[1]);
            Assert.AreEqual(0x34, byteNum[2]);
            Assert.AreEqual(0x12, byteNum[3]);
        }

        /// <summary>
        ///Int64ToByte 的测试
        ///</summary>
        [TestMethod()]
        public void Int64ToByteTest()
        {
            Int64 intNum = 0x0123456789ABCDEF;
            byte[] byteNum = new byte[8];

            bool result = NetBase.Int64ToByte(intNum, byteNum, 0);
            Assert.AreEqual(0xEF, byteNum[0]);
            Assert.AreEqual(0xCD, byteNum[1]);
            Assert.AreEqual(0xAB, byteNum[2]);
            Assert.AreEqual(0x89, byteNum[3]);
            Assert.AreEqual(0x67, byteNum[4]);
            Assert.AreEqual(0x45, byteNum[5]);
            Assert.AreEqual(0x23, byteNum[6]);
            Assert.AreEqual(0x01, byteNum[7]);
        }
    }
}
