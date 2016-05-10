using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class SEndBatchProcessRep : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_SENDBATCHPROCESSREP;

        public UInt32 result;
        public List<netmessage.LeafGradeCount> leaf_grade_counts;
        public byte[] marshalData;

        public SEndBatchProcessRep()
        {
            this.result = 0;
        }

        public SEndBatchProcessRep(UInt32 result)
        {
            this.result = result;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            ServerClient client = (ServerClient)userdata;
            client.OnSEndBatchProcessRep(result, leaf_grade_counts);
        }

        public void Marshal()
        {
            netmessage.SEndBatchProcessRepProto proto = new netmessage.SEndBatchProcessRepProto();
            proto.result = this.result;
            proto.leaf_grade_counts.Clear();
            foreach(netmessage.LeafGradeCount lgc in this.leaf_grade_counts)
            {
                proto.leaf_grade_counts.Add(lgc);
            }
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.SEndBatchProcessRepProto>(ms, proto);
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
            netmessage.SEndBatchProcessRepProto proto = new netmessage.SEndBatchProcessRepProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.SEndBatchProcessRepProto>(ms);
            ms.Close();
            this.result = proto.result;
            this.leaf_grade_counts = proto.leaf_grade_counts;
        }

        public override Protocol Clone()
        {
            return new SEndBatchProcessRep();
        }
    }
}
