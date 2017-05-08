using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.Models
{
    public class Device
    {
        private string serialNumber;

        private byte slaveId;

        public void SetSerialNumber(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public void SetSlaveId(byte slaveId)
        {
            this.slaveId = slaveId;
        }

        public byte GetSlaveId()
        {
            return this.slaveId;
        }

        public float GetMeasure()
        {
            Console.WriteLine($"Connecting to {slaveId}");

            float result = 5.05f;

            Console.WriteLine($"Result {result} from {slaveId}");

            return result;
        }

    }
}
