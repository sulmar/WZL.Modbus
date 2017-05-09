using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WZL.Modbus.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo response;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Wybierz rodzaj pomiaru:");
                Console.WriteLine("(T)emperature");
                Console.WriteLine("(V)oltage");
                Console.WriteLine("(B)inary");

                response = Console.ReadKey(true);

                switch (response.KeyChar)
                {
                    case 'T': GetTemperatureTest(); break;
                    case 'V': GetVoltageTest(); break;
                    case 'B': SetBinaryTest(); break;
                }
            }
            while (response.Key != ConsoleKey.Escape);


        }

        private static void SetBinaryTest()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var slaveId = byte.Parse(ConfigurationManager.AppSettings["SM4"]);

            ushort startAddress = 2200;

            Console.WriteLine($"Connecting to {hostname}:{port}");

            try
            {
                using (var client = new TcpClient(hostname, port))
                using (var master = ModbusIpMaster.CreateIp(client))
                {
                    Console.WriteLine("Connected.");

                    // Przykładowe wartości
                    bool[] outputs = { true, false, true, true };

                    master.WriteMultipleCoils(slaveId, startAddress, outputs);

                    bool[] inputs = master.ReadCoils(slaveId, startAddress, 4);

                    Console.WriteLine(String.Join(", ", inputs));

                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("Błąd połączenia. Sprawdź okablowanie oraz konfigurację.");
            }
        }

        private static void GetVoltageTest()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var slaveId = byte.Parse(ConfigurationManager.AppSettings["N30H_VoltDC"]);

            ushort startAddress = 7010;
            ushort numRegisters = 2;

            Console.WriteLine($"Connecting to {hostname}:{port}");

            try
            {
                using (var client = new TcpClient(hostname, port))
                using (var master = ModbusIpMaster.CreateIp(client))
                {
                    Console.WriteLine("Connected.");

                    Console.WriteLine("Press any key to exit.");

                    while (!Console.KeyAvailable)
                    {
                        ushort[] inputs = master.ReadInputRegisters(slaveId, startAddress, numRegisters);

                        float voltage = Converter.ConvertToFloat(inputs[0], inputs[1]);

                        Console.WriteLine($"Voltage : {voltage} V");

                        Thread.Sleep(1000);
                    }
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("Błąd połączenia. Sprawdź okablowanie oraz konfigurację.");
            }

        }

        private static void GetTemperatureTest()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var slaveId = byte.Parse(ConfigurationManager.AppSettings["N30U_Temp"]);

            ushort startAddress = 7010;
            ushort numRegisters = 2;

            Console.WriteLine($"Connecting to {hostname}:{port}");

            // Określa zakres działania obiektu i utomatycznie wywołanie metodę Dispose
            // UWAGA: using można użyć tylko dla obiektów, które implementują interfejs IDisposable

            try
            {
                using (var client = new TcpClient(hostname, port))
                using (var master = ModbusIpMaster.CreateIp(client))
                {
                    Console.WriteLine("Connected.");

                    Console.WriteLine("Press any key to exit.");

                    while (!Console.KeyAvailable)
                    {
                        ushort[] inputs = master.ReadInputRegisters(slaveId, startAddress, numRegisters);

                        float temperature = Converter.ConvertToFloat(inputs[0], inputs[1]);

                        Console.WriteLine($"Temperature: {temperature} °C");

                        Thread.Sleep(1000);
                    }
                }

            }
            catch(SocketException e)
            {
                Console.WriteLine("Błąd połączenia. Sprawdź okablowanie oraz konfigurację.");
            }



        }
    }
}
