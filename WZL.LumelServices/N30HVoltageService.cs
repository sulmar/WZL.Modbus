using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WZL.Services;

namespace WZL.LumelServices
{
    public class N30HVoltageService : IAnalogInput
    {
        private string hostname;
        private int port;
        private byte slaveId;

        const ushort startAddress = 7010;
        const ushort numRegisters = 2;

        // ctor
        public N30HVoltageService()
        {
            hostname = ConfigurationManager.AppSettings["hostname"];
            port = int.Parse(ConfigurationManager.AppSettings["port"]);
            slaveId = byte.Parse(ConfigurationManager.AppSettings["N30H_VoltDC"]);
        }

        public N30HVoltageService(string hostname, int port, byte slaveId)
        {
            this.hostname = hostname;
            this.port = port;
            this.slaveId = slaveId;
        }


        public float Get()
        {
            using (var client = new TcpClient(hostname, port))
            using (var master = ModbusIpMaster.CreateIp(client))
            {
                ushort[] inputs = master.ReadInputRegisters(slaveId, startAddress, numRegisters);

                float voltage = Converter.ConvertToFloat(inputs);

                return voltage;

            }
        }
    }
}
