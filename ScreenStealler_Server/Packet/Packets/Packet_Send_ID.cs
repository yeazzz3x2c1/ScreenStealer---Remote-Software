using ScreenStealler_Network;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Server.Packet.Packets
{
    internal class Packet_Send_ID : Packet_Base<Packet_Types>
    {
        long ID;
        public override void Decode(byte[] raw_data)
        {

        }

        public override byte[] Encode()
        {
            byte[] result = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                result[i] = (byte)(ID & 0xff);
                ID >>= 8;
            }
            return result;
        }

        public override void Execute(Client<Packet_Types> client)
        {
            ScreenStealler_Client<Packet_Types> ss_client = (ScreenStealler_Client<Packet_Types>)client;
            ID = ss_client.Get_ID();
            client.Send_Message(this);
        }

        public override Packet_Types Get_Type() => Packet_Types.Send_ID;
    }
}
