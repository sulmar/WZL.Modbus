using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.Models
{
    public class Device
    {
        private string serialNumber; // back field

        // właściwość (property)
        public string SerialNumber
        {
            get
            {
                return this.serialNumber;
            }

            set
            {
                this.serialNumber = value;
            }
        }


        private byte slaveId;

        public byte SlaveId
        {
            get
            {
                return this.slaveId;
            }

            set
            {
                this.slaveId = value;
            }
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
