﻿using ScreenStealler_Client.Packet;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Client.Packets
{
    internal class Packet_Send_ID : Packet_Base<Packet_Types>
    {
        private long ID;
        public override void Decode(byte[] raw_data)
        {
            ID = 0;
            for (int i = 0; i < 8; i++)
                ID |= raw_data[i] << (i << 3);
        }

        public override byte[] Encode()
        {
            return new byte[] { 0 };
        }

        public override void Execute(Client<Packet_Types> client)
        {
            Global.Set_ID(ID);
        }

        public override Packet_Types Get_Type() => Packet_Types.Send_ID;
    }
}