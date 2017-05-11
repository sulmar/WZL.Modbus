using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.Models
{
    public class Device : Object
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

        // Właściwość - wersja skrócona (snippet: prop)
        public byte SlaveId { get; set; }

        public string Model { get; set; }

        public string Manufacture { get; set; }

        public float CurrentValue { get; set; }


        // Metoda generyczna
        // (jest to szablon metody na podstawie której 
        // generowany jest kod do obsługi podanego typu)
        public TMeasure GetMeasure<TMeasure>()
        {
            Console.WriteLine($"Connecting to {SlaveId}");

            TMeasure result = default(TMeasure);

            Console.WriteLine($"Result {result} from {SlaveId}");

            return result;
        }


        //public float GetFloatMeasure()
        //{
        //    Console.WriteLine($"Connecting to {SlaveId}");

        //    float result = 5.05f;

        //    Console.WriteLine($"Result {result} from {SlaveId}");

        //    return result;
        //}


        //public bool GetBoolMeasure()
        //{
        //    Console.WriteLine($"Connecting to {SlaveId}");

        //    bool result = true;

        //    Console.WriteLine($"Result {result} from {SlaveId}");

        //    return result;
        //}

        //public DateTime GetDatetimeMeasure()
        //{
        //    Console.WriteLine($"Connecting to {SlaveId}");

        //    DateTime result = DateTime.Now;

        //    Console.WriteLine($"Result {result} from {SlaveId}");

        //    return result;
        //}

        public Device()
        {
            this.Manufacture = "Lumel";
        }

        public Device(byte slaveId)
        {
            this.SlaveId = slaveId;
        }

    }
}
