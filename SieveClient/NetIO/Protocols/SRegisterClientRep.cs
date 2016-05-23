using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class SRegisterClientRep : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_SREGISTERCLIENTREP;

        public UInt32 result;
        public Int32 samples_count;
        public byte[] marshalData;

        public SRegisterClientRep()
        {
            result = 0;
            samples_count = 0;
        }

        public SRegisterClientRep(UInt32 result, Int32 samples_count)
        {
            this.result = result;
            this.samples_count = samples_count;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            ServerClient client = (ServerClient)userdata;
            client.OnSRegisterClientRep(result, samples_count);
        }

        public void Marshal()
        {
            netmessage.SRegisterClientRepProto proto = new netmessage.SRegisterClientRepProto();
            proto.result = this.result;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.SRegisterClientRepProto>(ms, proto);
            netmessage.CProto cproto = new netmessage.CProto();
            cproto.id = ProtocoID;
            cproto.body = ms.ToArray();
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
            netmessage.SRegisterClientRepProto proto = new netmessage.SRegisterClientRepProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.SRegisterClientRepProto>(ms);
            ms.Close();
            this.result = proto.result;
            this.samples_count = proto.samples_count;
        }

        public override Protocol Clone()
        {
            return new SRegisterClientRep();
        }
    }
}
