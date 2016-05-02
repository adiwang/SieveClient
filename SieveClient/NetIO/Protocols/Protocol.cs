using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    public abstract class Protocol
    {
        public virtual void Process(byte[] data, int len, object userdata) { }
        public abstract Protocol Clone();
    }

    public class CProtocol1 : Protocol
    {
        public const int ProtocoID = 1;

        public Int32 a;
        public Int64 b;
        public string c;
        public byte[] marshalData;

        public CProtocol1()
        {
            a = 0;
            b = 0;
            c = "";
        }

        public CProtocol1(Int32 a, Int64 b, string c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            Console.WriteLine("CProtocol1: a={0}, b={1}, c={2}", a, b, c);
        }

        public void Marshal()
        {
            netmessage.CP1 cp1 = new netmessage.CP1();
            cp1.a = this.a;
            cp1.b = this.b;
            cp1.c = this.c;
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
            marshalData = PacketBuilder.Build(ref packetHead, data);
        }

        public void UnMarshal(byte[] data)
        {
            netmessage.CP1 cp1 = new netmessage.CP1();
            MemoryStream ms = new MemoryStream(data);
            cp1 = ProtoBuf.Serializer.Deserialize<netmessage.CP1>(ms);
            ms.Close();
            this.a = cp1.a;
            this.b = cp1.b;
            this.c = cp1.c;
        }

        public override Protocol Clone()
        {
            return new CProtocol1();
        }
    }

}
