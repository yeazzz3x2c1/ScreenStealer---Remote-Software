using ScreenStealler_Network.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Network.Network
{
    public class Remote_Client<T> : Client<T>
    {
        public Remote_Client(Socket socket, Dictionary<T, Type> packet_2_index)
        {
            this.socket = socket;
            is_online = true;
            this.packet_2_index = packet_2_index;
        }
    }
}
