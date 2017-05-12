using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WZL.Services;

namespace WZL.EAServices
{
    public class SupplierService : IVoltageOutputService, ICurrentOutputService, IOutputService, 
        IVoltageInputService, ICurrentInputService
    {
        private string hostname;
        private int port;


        public SupplierService()
        {
            hostname = ConfigurationManager.AppSettings["supplierHostname"];
            port = int.Parse(ConfigurationManager.AppSettings["supplierPort"]);
        }

        void IOutputService.Off()
        {
            Send("OUTPUT OFF");
        }

        void IOutputService.On()
        {
            Send("OUTPUT ON");
        }

        void ICurrentOutputService.Set(float value)
        {
            Send("SYST:LOCK ON");
            Send($"CURRENT {value.ToString(CultureInfo.InvariantCulture)}");
        }

        void IVoltageOutputService.Set(float value)
        {
            Send("SYST:LOCK ON");
            Send($"VOLT {value.ToString(CultureInfo.InvariantCulture)}");
        }

        private string Send(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);

            using (var client = new TcpClient(hostname, port))
            using (var stream = client.GetStream())
            {
                client.SendTimeout = 1000; // ms
                stream.Write(data, 0, data.Length);

                byte[] lf = { (byte)'\n' };

                stream.Write(lf, 0, 1);

                // Pobieranie odpowiedzi
                if (command.IndexOf("?") >= 0)
                {
                    byte[] buffer = new byte[128];

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    string response = Encoding.ASCII.GetString(buffer);

                    return response;
                }
                else
                    return string.Empty;
            }
        }

        public bool IsOn()
        {
            var response = Send("OUTPUT?");

            var result = response.StartsWith("ON");

            return result;
        }

        float IVoltageInputService.Get()
        {
            var response = Send("MEAS:VOLT?");

            float result = Convert(response);

            return result;
        }

        float ICurrentInputService.Get()
        {
            var response = Send("MEAS:CURRENT?");

            float result = Convert(response);

            return result;
        }

        private static float Convert(string response)
        {
            // Zwraca pozycję znaku
            var index = response.IndexOf(' ');

            // Wycina określoną ilość znaków od podanej pozycji 
            var number = response.Substring(0, index);

            float result = float.Parse(number, CultureInfo.InvariantCulture);

            return result;
        }

      
    }
}
