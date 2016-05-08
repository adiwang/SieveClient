using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class CLearnSampleReq : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_CLEARNSAMPLEREQ;

        public Int32 group;
        public Int32 rank;
        public byte[] marshalData;

        public CLearnSampleReq()
        {
            group = 0;
            rank = 0;
        }

        public CLearnSampleReq(Int32 group, Int32 rank)
        {
            this.group = group;
            this.rank = rank;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            //TODO:
        }

        public void Marshal()
        {
            netmessage.CLearnSampleReqProto proto = new netmessage.CLearnSampleReqProto();
            proto.group = this.group;
            proto.rank = this.rank;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.CLearnSampleReqProto>(ms, proto);
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
            netmessage.CLearnSampleReqProto proto = new netmessage.CLearnSampleReqProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.CLearnSampleReqProto>(ms);
            ms.Close();
            this.group = proto.group;
            this.rank = proto.rank;
        }

        public override Protocol Clone()
        {
            return new CLearnSampleReq();
        }
    }
}
