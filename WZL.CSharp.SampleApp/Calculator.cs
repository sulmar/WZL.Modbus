using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.CSharp.Models;

namespace WZL.CSharp.SampleApp
{
    class Parameters
    {
        public float Current { get; set; }

        public float Volt { get; set; }

        public float Power { get; set; }

        public float Ratio { get; set; }
    }


    internal class Calculator
    {
        public void Calculate(string model, float currentValue, float volt, float power)
        {
            
        }

        public void Calculate(Parameters parameters)
        {

        }

        public void Calculate(Device device, float volt)
        {
            Console.WriteLine($"Connecting to {device.SlaveId}");

            device.CurrentValue = volt * 2f;

        }

        private void Init()
        {

        }

        public static void Print(int x)
        {
            Console.WriteLine(x);
        }


        // Przeciążanie metod
        public static int Add(int x, int y)
        {
          //  Init();

            int result = x + y;

            return result;
        }

        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        // TODO: Dodaj metodę do mnożenia 2 liczb całkowitych o nazwie Multiply


        // Parametr opcjonalny
        public int Multiply(int x, int y, int z = 1)
        {
            return x * y * z;
        }

        // C# 7.0

        //public (int i , int j) Extract(int x, int y, int z)
        //{
        //    return new { i = 10, j = 2 };
        //}
    }
}
