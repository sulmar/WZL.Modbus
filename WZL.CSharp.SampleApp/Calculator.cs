using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.SampleApp
{
    internal class Calculator
    {
        


        private void Init()
        {

        }

        private void Print(int x)
        {
            Console.WriteLine(x);
        }


        // Przeciążanie metod
        public int Add(int x, int y)
        {
            Init();

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
