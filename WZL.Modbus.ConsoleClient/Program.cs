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
            GetVoltageTest();

            GetTemperatureTest();
        }

        private static void GetVoltageTest()
        {
            var hostname = ConfigurationManager.AppSettings["hostname"];
            var port = int.Parse(ConfigurationManager.AppSettings["port"]);
            var slaveId = byte.Parse(ConfigurationManager.AppSettings["N30H_VoltDC"]);

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

                        float voltage = Converter.ConvertToFloat(inputs[0], inputs[1]);

                        Console.WriteLine($"Voltage: {voltage} V");

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
