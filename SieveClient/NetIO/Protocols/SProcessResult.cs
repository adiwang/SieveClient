using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class SProcessResult : Protocol
    {
        public const int ProtocoID = Convert.ToInt32(ProtocolID.PROTOCOL_ID_SPROCESSFEATUREREP);

        public UInt32 result;
        public byte[] marshalData;

        public SProcessResult()
        {
            result = 0;
        }

        public SProcessResult(UInt32 result)
        {
            this.result = result;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            //TODO: 注册成功逻辑
        }

        public void Marshal()
        {
            netmessage.SProcessResultProto proto = new netmessage.SProcessResultProto();
            proto.result = this.result;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.SProcessResultProto>(ms, proto);
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
            netmessage.SProcessResultProto proto = new netmessage.SProcessResultProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.SProcessResultProto>(ms);
            ms.Close();
            this.result = proto.result;
        }

        public override Protocol Clone()
        {
            return new SProcessResult();
        }
    }
}
