using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.CSharp.Models;

namespace WZL.CSharp.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.Write("Podaj imię: ");

            string firstname = Console.ReadLine();

            Console.WriteLine("Witaj " + firstname);

            Device device = new Device();
        }
    }

}
