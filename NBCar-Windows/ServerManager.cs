using NBCar_Windows.packet;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace NBCar_Windows
{
    class ServerManager
    {
        private static Socket ss;
        private static bool connect = false;

        public static void Init()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 3000);
            ss = new Socket(ipep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            ss.Bind(ipep);
            ss.Listen(0);
            Thread thread = new Thread(new ThreadStart(Listen));
            thread.Start();
        }

        public static void Listen()
        {
            while (true)
            {
                connect = false;
                Socket client = ss.Accept();
                connect = true;
                try
                {
                    while (true)
                    {

                        double leftScale = (double)DataManager.GetLeftPower() / DataManager.MAX_POWER;
                        double rightScale = (double)DataManager.GetRightPower() / DataManager.MAX_POWER;

                        var packet = new ServerStatusPacket((short)(leftScale * short.MaxValue), (short)(rightScale * short.MaxValue));
                        var frame = packet.Build();
                        client.Send(frame, frame.Length, SocketFlags.None);
                        Thread.Sleep(20);
                    }
                }
                catch { }
            }
        }

        public static bool IsConnect()
        {
            return connect;
        }
    }
}
