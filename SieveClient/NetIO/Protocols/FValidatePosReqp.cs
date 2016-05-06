using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class FValidatePosReqp : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_FVALIDATEPOSREQP;

        public UInt32 result;
        public string image_path;
        public byte[] marshalData;

        public FValidatePosReqp()
        {
            result = 0;
            image_path = null;
        }

        public FValidatePosReqp(UInt32 result, string image_path)
        {
            this.result = result;
            this.image_path = image_path;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            ServerClient client = (ServerClient)userdata;
            client.OnFValidatePosReqp(result, image_path);
        }

        public void Marshal()
        {
            netmessage.FValidatePosReqpProto proto = new netmessage.FValidatePosReqpProto();
            proto.result = this.result;
            proto.image_path = this.image_path;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.FValidatePosReqpProto>(ms, proto);
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
            netmessage.FValidatePosReqpProto proto = new netmessage.FValidatePosReqpProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.FValidatePosReqpProto>(ms);
            ms.Close();
            this.result = proto.result;
            this.image_path = proto.image_path;
        }

        public override Protocol Clone()
        {
            return new FValidatePosReqp();
        }
    }
}
