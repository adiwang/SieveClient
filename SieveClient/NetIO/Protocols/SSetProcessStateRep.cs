﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetIO
{
    class SSetProcessStateRep : Protocol
    {
        public const int ProtocoID = (int)ProtocolID.PROTOCOL_ID_SSETPROCESSSTATEREP;

        public UInt32 result;
        public byte[] marshalData;

        public SSetProcessStateRep()
        {
            this.result = 0;
        }

        public SSetProcessStateRep(UInt32 result)
        {
            this.result = result;
        }

        public override void Process(byte[] data, int len, object userdata)
        {
            UnMarshal(data);
            ServerClient client = (ServerClient)userdata;
            client.OnSSetProcessStateRep(result);
        }

        public void Marshal()
        {
            netmessage.SSetProcessStateRepProto proto = new netmessage.SSetProcessStateRepProto();
            proto.result = this.result;
            MemoryStream ms = new MemoryStream();
            ProtoBuf.Serializer.Serialize<netmessage.SSetProcessStateRepProto>(ms, proto);
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
            netmessage.SSetProcessStateRepProto proto = new netmessage.SSetProcessStateRepProto();
            MemoryStream ms = new MemoryStream(data);
            proto = ProtoBuf.Serializer.Deserialize<netmessage.SSetProcessStateRepProto>(ms);
            ms.Close();
            this.result = proto.result;
        }

        public override Protocol Clone()
        {
            return new SSetProcessStateRep();
        }
    }
}
