using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnTapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            #region De3
            //IPEndPoint ipe_sv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            //Socket client = new Socket(SocketType.Dgram, ProtocolType.Udp);

            //client.Connect(ipe_sv);
            //Console.WriteLine("Ket noi thanh cong");

            //Console.WriteLine("Nhap ki tu");
            //string send = Console.ReadLine();
            //byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);
            //client.SendTo(bSend, ipe_sv);

            //EndPoint fakeEndPoint = new IPEndPoint(IPAddress.Any, 0);
            //byte[] bReceive = new byte[1024];
            //int len = client.ReceiveFrom(bReceive, ref fakeEndPoint);
            //string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, len);
            //Console.WriteLine("<Server>: " + message);
            #endregion

            #region De4
            //IPEndPoint ipe_sv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            //Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //client.Connect(ipe_sv);
            //Console.WriteLine("Ket noi thanh cong");

            //int a, b;
            //do
            //{
            //    try
            //    {
            //        Console.WriteLine("Nhap a: ");
            //        a = Convert.ToInt32(Console.ReadLine());

            //        Console.WriteLine("Nhap b: ");
            //        b = Convert.ToInt32(Console.ReadLine());
            //        if (a <= 0 || b <= 0)
            //        {
            //            Console.WriteLine("Nhap so nguyen duong");
            //        }
            //        else break;
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("Nhap so nguyen duong");
            //    }
            //} while (true);

            //string mess = $"{a}-{b}";
            //byte[] send = ASCIIEncoding.ASCII.GetBytes(mess);
            //client.SendTo(send, ipe_sv);

            //byte[] receive = new byte[1024];
            //var len = client.Receive(receive, SocketFlags.None);
            //string bmess = ASCIIEncoding.ASCII.GetString(receive, 0, len);
            //Console.WriteLine($"<Server>: {bmess}");
            #endregion

            //De2
            IPEndPoint ipe_sv = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe_sv);
            Console.WriteLine("Ket noi thanh cong");

            double a, b;
            do
            {
                try
                {
                    Console.WriteLine("Nhap a: ");
                    a = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Nhap b: ");
                    b = Convert.ToDouble(Console.ReadLine());

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Nhap dinh dang so");
                }
            } while (true);

            string mess = $"{a}-{b}";
            byte[] send = ASCIIEncoding.ASCII.GetBytes(mess);
            client.SendTo(send, ipe_sv);

            byte[] receive = new byte[1024];
            var len = client.Receive(receive, SocketFlags.None);
            string bmess = ASCIIEncoding.ASCII.GetString(receive, 0, len);
            Console.WriteLine($"<Server>: {bmess}");

            Console.ReadLine();
        }
    }
}
