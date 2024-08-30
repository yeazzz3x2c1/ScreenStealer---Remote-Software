using ScreenStealler_Client.Packet;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenStealler_Client.Packets
{
    internal class Packet_Connect_To_ID : Packet_Base<Packet_Types>
    {
        private long ID;
        private bool success = false;
        public override void Decode(byte[] raw_data)
        {
            success = raw_data[0] == 1;
        }
        public void Set_ID(long ID)
        {
            this.ID = ID;
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
            MessageBox.Show("連線結果: " + success);
        }

        public override Packet_Types Get_Type() => Packet_Types.Connect_To_ID;
    }
}
