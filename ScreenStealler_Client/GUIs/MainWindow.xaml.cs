using ScreenStealler_Client.Packet;
using ScreenStealler_Client.Packets;
using ScreenStealler_Network.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenStealler_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client<Packet_Types>? client;
        public MainWindow()
        {
            InitializeComponent();
            Global.Set_Task_Scheduler(TaskScheduler.FromCurrentSynchronizationContext());
            Global.On_ID_Set += (ID) =>
            {
                ID_TextBlock.Text = ID.ToString();
                Remote_ID.Text = ID.ToString();
            };
            Loaded += delegate
            {
                client = Network_Manager.Create_Client(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 25535));
                client.Send_Message(new Packet_Send_ID());
            };
            Closing += delegate
            {
                client?.Close();
            };
        }

        private void On_Connect_Clicked(object sender, RoutedEventArgs e)
        {
            long id = long.Parse(Remote_ID.Text);
            Packet_Connect_To_ID connect_to_id = new Packet_Connect_To_ID();
            connect_to_id.Set_ID(id);
            client?.Send_Message(connect_to_id);
        }
    }
}
