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

        // Właściwość - wersja skrócona
        public byte SlaveId { get; set; }

        public string Model { get; set; }

        public string Manufacture { get; set; }

        public float GetMeasure()
        {
            Console.WriteLine($"Connecting to {SlaveId}");

            float result = 5.05f;

            Console.WriteLine($"Result {result} from {SlaveId}");

            return result;
        }

    }
}
