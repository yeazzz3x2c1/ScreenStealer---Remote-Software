using ScreenStealler_Client.Packet;
using ScreenStealler_Client.Packets;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Client
{
    internal class Network_Manager
    {
        public static Client<Packet_Types> Create_Client(IPEndPoint server_end_point)
        {
            Dictionary<Packet_Types, Type> packet_2_type = new Dictionary<Packet_Types, Type>()
            {
                {Packet_Types.Send_ID, typeof(Packet_Send_ID) },
                {Packet_Types.Connect_To_ID, typeof(Packet_Connect_To_ID) },
            };
            Client<Packet_Types> client = new Client<Packet_Types>(server_end_point, packet_2_type, Packet_Types.Heartbeat);
            client.Listen();
            return client;
        }
    }
}
