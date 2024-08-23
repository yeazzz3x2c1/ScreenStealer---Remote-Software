using ScreenStealler_Network.Network;
using System.Net.Sockets;

namespace ScreenStealler_Network
{
    internal class ScreenStealler_Client<T> : Remote_Client<T>
    {
        private long ID = 0;
        private string Password = "";

        public ScreenStealler_Client(Socket socket, Dictionary<T, Type> packet_2_index) : base(socket, packet_2_index)
        {
            ID = DateTime.Now.Ticks % 1000000000;
            Password = Global.Generate_Random_String(6);
        }
        public long Get_ID() => ID;
        public int Get_Screen()
        {
            return 0;
        }
        public void Set_Display_Screen(int Image)
        {

        }
        public void Send_Mouse_Position(int x, int y)
        {

        }
        public void Send_Keyboard_Status(Keyboard_Control control, Key_Code key)
        {

        }
        public bool Is_Password_Valid(string Password) => this.Password.Equals(Password);
    }
}
