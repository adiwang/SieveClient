using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class SLearnSampleRep : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_SLEARNSAMPLEREP;

        public UInt32 result;
        public Int32 group;
        public Int32 rank;
        public byte[] marshalData;

        public SLearnSampleRep()
        {
            result = 0;
            group = 0;
            rank = 0;
        }

        public SLearnSampleRep(UInt32 result, Int32 group, Int32 rank)
        {
            this.result = result;
            this.group = group;
            this.rank = rank;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            ServerClient client = (ServerClient)userdata;
            client.OnSRegisterClientRep(result);
        }

        public void Marshal()
        {
            netmessage.SLearnSampleRepProto proto = new netmessage.SLearnSampleRepProto();
            proto.result = this.result;
            proto.group = this.group;
            proto.rank = this.rank;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.SLearnSampleRepProto>(ms, proto);
            netmessage.CProto cproto = new netmessage.CProto();
            cproto.id = ProtocoID;
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
            netmessage.SLearnSampleRepProto proto = new netmessage.SLearnSampleRepProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.SLearnSampleRepProto>(ms);
            ms.Close();
            this.result = proto.result;
            this.group = proto.group;
            this.rank = proto.rank;
        }

        public override Protocol Clone()
        {
            return new SLearnSampleRep();
        }
    }
}
