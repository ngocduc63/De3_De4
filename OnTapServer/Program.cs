using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnTapServer
{
    class Program
    {
        // de 3:
        static bool checkKeyWord(string key)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return Array.IndexOf(vowels, key) >= 0;
        }
        // de 4:
        static int USCLN(int a, int b)
        {
            if (b == 0) return a;
            return USCLN(b, a % b);
        }

        static string GiaiPhuongTrinhBacNhat(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                return "Phuong trinh co vo so nghiem";
            }
            else if (a == 0 && b != 0)
            {
                return "Phuong trinh vo nghiem";

            }
            else
            {
                return $"Phuong trinh co nghiem la: x = {-b / a}";
            }
        }
        static void Main(string[] args)
        {
            #region De3
            //try
            //{
            //    IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 8888);
            //    Socket server = new Socket(SocketType.Dgram, ProtocolType.Udp);
            //    server.Bind(ipe);
            //    Console.WriteLine("Cho ket noi..");

            //    do
            //    {
            //        EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            //        byte[] bReceive = new byte[1024];
            //        int len = server.ReceiveFrom(bReceive, ref endPoint);
            //        string message = ASCIIEncoding.ASCII.GetString(bReceive, 0, len);
            //        Console.WriteLine("<Client>: " + message);

            //        string send = "";
            //        if (message.Trim().Length != 1)
            //        {
            //            send = "Gia tri khong dung";
            //        }
            //        else
            //        {
            //            send = checkKeyWord(message) ? "Nguyen am" : "Phu am";
            //        }
            //        byte[] bSend = ASCIIEncoding.ASCII.GetBytes(send);
            //        server.SendTo(bSend, endPoint);

            //    } while (true);
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.ToString());
            //}
            #endregion

            #region De4
            //IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 8888);
            //Socket sever = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //Console.WriteLine("Cho ket noi");
            //sever.Bind(ipe);
            //sever.Listen(10);

            //do
            //{
            //    Socket client = sever.Accept();
            //    Console.WriteLine("Co ket noi");

            //    byte[] receive = new byte[1024];
            //    var len = client.Receive(receive, SocketFlags.None);
            //    string mess = ASCIIEncoding.ASCII.GetString(receive, 0, len);
            //    Console.WriteLine($"<Client>: {mess}");

            //    int a = Convert.ToInt32(mess.Split('-')[0]);
            //    int b = Convert.ToInt32(mess.Split('-')[1]);

            //    string bmess = "";
            //    if (a <= 0 || b <= 0)
            //    {
            //        bmess = "Nhap khong dung so nguyen duong";
            //    }
            //    else
            //    {
            //        bmess = $"UCLN cua {a} va {b} la {USCLN(a, b)}";
            //    }

            //    byte[] send = ASCIIEncoding.ASCII.GetBytes(bmess);
            //    client.SendTo(send, ipe);

            //} while (true);
            #endregion

            // De2
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 8888);
            Socket sever = new Socket(SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Cho ket noi");
            sever.Bind(ipe);
            sever.Listen(10);

            do
            {
                Socket client = sever.Accept();
                Console.WriteLine("Co ket noi");

                byte[] receive = new byte[1024];
                var len = client.Receive(receive, SocketFlags.None);
                string mess = ASCIIEncoding.ASCII.GetString(receive, 0, len);
                Console.WriteLine($"<Client>: {mess}");

                double a = Convert.ToDouble(mess.Split('-')[0]);
                double b = Convert.ToDouble(mess.Split('-')[1]);

                string bmess = GiaiPhuongTrinhBacNhat(a, b);
                byte[] send = ASCIIEncoding.ASCII.GetBytes(bmess);
                client.SendTo(send, ipe);

            } while (true);

            Console.ReadLine();
        }
    }
}
