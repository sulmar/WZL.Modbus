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
            float result = 5.06f;

            float result2 = result;

            result2 = result2 + 1;

            // Inicjalizacja obiektu za pomocą inicjalizatorów
            Device device = new Device
            {
                SlaveId = 2, 
                Manufacture = "Siemens",
                Model = "PD8",
                SerialNumber = "S/N 001",
            };

            Console.WriteLine(device.SerialNumber);

            Device device2 = device;
            device2.Manufacture = "Lumel";

            //device.slaveId = 1;
            //device.serialNumber = "S/N 123";

         



            MethodsTest();

            NullableTest();

            ConvertTest();

            TypesTest();

            HelloWorldTest();
        }

        private static void MethodsTest()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(10, 20);

            calculator.Multiply(10, 2, 3);
        }

        private static void NullableTest()
        {
            Nullable<int> age = null;

            // int? age = null;

            if (!age.HasValue)
            {
                Console.WriteLine("Wartość nieokreślona");
            }
            else
            {
                Console.WriteLine(age.Value);
            }
        }

        private static void ConvertTest()
        {
            byte x = 255;
            int y = x; // niejawna konwersja (Impicit Conversion)

            int a = 252;

            // sprawdzanie przekroczenia zakresu
            checked
            {
                byte b = (byte)a; // jawna konwersja (Explicit Conversion)
            }

            float voltage = 5.06f;

            double output = voltage;

            double amper = 10.3004d; // niejawna konwersja

            float input = (float)amper; // jawna konwersja

            // Konwersja tekstu na liczbę

            Console.Write("Podaj zakres: ");
            string response = Console.ReadLine();

            // int range = int.Parse(response);

            //  float lowBound = float.Parse(response);

            int quantity;

            if (int.TryParse(response, out quantity))
            {
                Console.WriteLine($"Ilość: {quantity}");
            }
            else
            {
                Console.WriteLine("Wprowadzono złą wartość");
            }
        }

        private static void TypesTest()
        {
            string firstname = "Marcin";
            char sign = 'a';

            char firstLetter = firstname[0];

            // typ bitowy
            bool bit = true;

            // typy liczbowe całkowite 

            byte x1 = 15; // 8 bitów
            sbyte x2 = -15; // 8 bitów ze znakiem

            // ze znakiem
            short a = -100; // Int16
            int b = 10; // Int32
            long c = 10; // Int64

            // bez znaku
            ushort e = 100; // Int16
            uint f = 10; // Int32
            ulong g = 10; // Int64

            // liczby ułamkowe

            // stałoprzecinkowe

            decimal amount = 100.04m;

            // liczby zmiennoprzecinkowe

            float voltage = 5.04f;

            double size = 100.01d;
        }

        private static void HelloWorldTest()
        {
            Console.WriteLine("Hello World!");

            Console.Write("Podaj imię: ");

            string firstname = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");

            string lastname = Console.ReadLine();

            // string message = String.Format("Witaj {0} {1}", firstname, lastname);

            // C# 6.0
            string message = $"Hello {firstname} {lastname} !";

            Console.WriteLine(message);

            Console.WriteLine("Szkolenie C#");

        }
    }

}
