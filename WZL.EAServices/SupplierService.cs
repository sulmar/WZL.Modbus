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
    public class SupplierService : IVoltageOutputService, ICurrentOutputService, IOutputService
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
            Send($"CURRENT {value.ToString(CultureInfo.InvariantCulture)}");
        }

        void IVoltageOutputService.Set(float value)
        {
            Send($"VOLT {value.ToString(CultureInfo.InvariantCulture)}");
        }

        private void Send(string command)
        {
            byte[] data = Encoding.ASCII.GetBytes(command);

            using (var client = new TcpClient(hostname, port))
            using (var stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);

                byte[] lf = { (byte)'\n' };

                stream.Write(lf, 0, 1);
            }
        }
    }
}
