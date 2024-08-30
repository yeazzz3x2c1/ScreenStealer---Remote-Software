using ScreenStealler_Network;
using ScreenStealler_Network.Network;

namespace ScreenStealler_Server.Packet.Packets
{
    internal class Packet_Connect_To_ID : Packet_Base<Packet_Types>
    {
        private long ID;
        private bool Success = false;
        public override void Decode(byte[] raw_data)
        {
            ID = 0;
            for (int i = 0; i < 8; i++)
                ID |= raw_data[i] << (i << 3);
        }

        public override byte[] Encode()
        {
            return new byte[] { (byte)(Success ? 1 : 0) };
        }

        public override void Execute(Client<Packet_Types> client)
        {
            Success = ScreenStealler_Client<Packet_Types>.Contains_Client_By_ID(ID);
            client.Send_Message(this);
        }

        public override Packet_Types Get_Type() => Packet_Types.Connect_To_ID;
    }
}
