using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WZL.SCPI.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            PingTest();

        }

        private static void PingTest()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);

            Console.WriteLine($"Connecting to {hostname}:{port}");

            while (true)
            {

                string command = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(command);

                using (var client = new TcpClient(hostname, port))
                {
                    Console.WriteLine("Connected.");

                    NetworkStream stream = client.GetStream();

                    stream.Write(data, 0, data.Length);

                    byte[] lf = { (byte)'\n' };

                    stream.Write(lf, 0, 1);

                    byte[] buffer = new byte[128];

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string response = Encoding.ASCII.GetString(buffer);

                    Console.WriteLine($"Response: {response}");
                }

            }
        }
    }
}
