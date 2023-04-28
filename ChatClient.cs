// Client socket to send and receive messages

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ClientSocket
{
    static Socket Client;
    static bool IsRunning = true;
    static void Main(string [] args)
    {
        string ServerAddress = "127.0.0.1";
        int ServerPort = 5987;

        Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(ServerAddress), ServerPort);
        Client.Connect(EndPoint);

        Thread SendThread = new Thread(SendMessage);
        Thread ReceiveThread = new Thread(ReceiveMessage);

        SendThread.Start();
        ReceiveThread.Start();

        SendThread.Join();
        ReceiveThread.Join();

        Client.Shutdown(SocketShutdown.Both);
        Client.Close();
    }

    static void SendMessage()
    {
        while (IsRunning)
        {
            string Message = Console.ReadLine();
            byte[] MessageBytes = Encoding.ASCII.GetBytes(Message);
            Client.Send(MessageBytes);
        }
    }

    static void ReceiveMessage()
    {
        while (IsRunning)
        {
            byte[] Buffer = new byte[1024];
            int BytesReceived = Client.Receive(Buffer);
            string ReceivedMessage = Encoding.ASCII.GetString(Buffer, 0, BytesReceived);
            Console.WriteLine(ReceivedMessage);
        }
    }
}
