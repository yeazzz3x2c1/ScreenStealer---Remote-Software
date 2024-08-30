
using ScreenStealler_Network;
using ScreenStealler_Network.Network;
using ScreenStealler_Server.Packet;
using ScreenStealler_Server.Packet.Packets;
int main()
{
    //Server<Packet_Types> server = new Server<Packet_Types>(Packet_Types.Heartbeat, new Heartbeat_Type_Getter());
    Server<Packet_Types> server = new Server<Packet_Types>(() => Packet_Types.Heartbeat);
    server.Set_Client_Getter((socket, packet_2_index) => new ScreenStealler_Client<Packet_Types>(socket, packet_2_index));
    server.Register_Packet(Packet_Types.Send_ID, typeof(Packet_Send_ID));
    server.Register_Packet(Packet_Types.Connect_To_ID, typeof(Packet_Connect_To_ID));

    server.Client_Online += (client) =>
    {
        Console.WriteLine($"Remote online: {client.Get_Remote_End_Point()}");
    };

    server.Client_Offline += (client) =>
    {
        Console.WriteLine($"Remote offline: {client.Get_Remote_End_Point()}");
    };
    server.Build_Up(25535);
    return 0;
}
main();