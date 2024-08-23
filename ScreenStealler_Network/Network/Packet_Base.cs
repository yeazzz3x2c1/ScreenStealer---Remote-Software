using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScreenStealler_Network.Network
{        
    public abstract class Packet_Base<T>
    {

        private byte[] raw_data = new byte[0];
        public abstract byte[] Encode(); // Properities => Raw Data
        public abstract void Decode(byte[] raw_data); // Raw Data => Properities
        public abstract void Execute(Client<T> client);
        public abstract T Get_Type();
    }
}
