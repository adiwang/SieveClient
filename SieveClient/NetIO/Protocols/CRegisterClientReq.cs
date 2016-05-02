using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class CRegisterClientReq : Protocol
    {
        public const int ProtocoID = Convert.ToInt32(ProtocolID.PROTOCOL_ID_CREGISTERCLIENTREQ);

        public UInt32 seq;
        public byte[] marshalData;

        public CRegisterClientReq()
        {
            seq = 0;
        }

        public CRegisterClientReq(UInt32 seq)
        {
            this.seq = seq;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            //TODO:
        }

        public void Marshal()
        {
            netmessage.CRegisterClientReqProto proto = new netmessage.CRegisterClientReqProto();
            proto.seq = this.seq;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.CRegisterClientReqProto>(ms, proto);
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
            netmessage.CRegisterClientReqProto proto = new netmessage.CRegisterClientReqProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.CRegisterClientReqProto>(ms);
            ms.Close();
            this.seq = proto.seq;
        }

        public override Protocol Clone()
        {
            return new CRegisterClientReq();
        }
    }
}
