using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class CEndBatchProcessReq : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_CENDBATCHPROCESSREQ;

        public Int32 state;
        public byte[] marshalData;

        public CEndBatchProcessReq()
        {
            this.state = 0;
        }

        public CEndBatchProcessReq(Int32 state)
        {
            this.state = state;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            //TODO:
        }

        public void Marshal()
        {
            netmessage.CEndBatchProcessReqProto proto = new netmessage.CEndBatchProcessReqProto();
            proto.state = this.state;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.CEndBatchProcessReqProto>(ms, proto);
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
            netmessage.CEndBatchProcessReqProto proto = new netmessage.CEndBatchProcessReqProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.CEndBatchProcessReqProto>(ms);
            ms.Close();
            this.state = proto.state;
        }

        public override Protocol Clone()
        {
            return new CEndBatchProcessReq();
        }
    }
}
