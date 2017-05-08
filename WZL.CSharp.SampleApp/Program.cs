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

            Console.Write("Podaj nazwisko: ");

            string lastname = Console.ReadLine();

            // string message = String.Format("Witaj {0} {1}", firstname, lastname);

            // C# 6.0
            string message = $"Witaj {firstname} {lastname}";

            Console.WriteLine(message);

            Device device = new Device();
        }
    }

}
