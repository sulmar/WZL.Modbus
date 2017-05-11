using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WZL.CSharp.Models;

namespace WZL.CSharp.SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device();
            Calculator calculator = new Calculator();

            calculator.Calculate(device, 10);

            calculator.Calculate(device.Model, device.CurrentValue, 10, 5);

            var parameters = new Parameters { Current = 5, Power = 3.0f, Volt = 5 };

            calculator.Calculate(parameters);


            Device device2 = device;

            calculator.Calculate(device2, 5);


            DynamicTest();

            GenericClassTest();

            GenericMethodTest();

            ArrayListTest();

            IfTest();

            LoadFileTest();

            InterfaceTest();

            ArrayTest();

            VarTest();

            AnonymuseType();

            InitTest();

            MethodsTest();

            NullableTest();

            ConvertTest();

            TypesTest();

            HelloWorldTest();
        }

        private static void GenericClassTest()
        {
            var printer = new Printer<string>();
            printer.Print("Hello");

            var numbersPrinter = new Printer<int>();
            numbersPrinter.Print(100);

            var device = new Device();
            var devicesPrinter = new Printer<Device>();
            devicesPrinter.Print(device);
        }

        private static void GenericMethodTest()
        {
            var device = new Device();

            var voltage = device.GetMeasure<float>();
            var bit = device.GetMeasure<bool>();
            var time = device.GetMeasure<DateTime>();
            var numbers = device.GetMeasure<int>();
        }

        private static void DynamicTest()
        {
            dynamic x = 100;

            x++;

            x = "Hello";
        }

        private static void ArrayListTest()
        {
            //var floatArray = new float[1000] ;
            //floatArray[0] = 5.05f;
            //floatArray[1] = "Hello";


            ArrayList measures = new ArrayList(3);

            measures.Add(4.05f);
            measures.Add(4.15f);
            measures.Add(4.35f);
            measures.Add(4.25f);
            measures.Add(4.15f);
            measures.Add("Hello");

            foreach (var measure in measures)
            {
                Console.WriteLine(measure);

                var result = (float) measure * 1.05f;
            }

        }

        private static void ListTest()
        {
            // Lista generyczna
            var measures = new List<float>();

            measures.Add(4.05f);
            measures.Add(4.15f);
            measures.Add(4.35f);
            measures.Add(4.25f);
            measures.Add(4.15f);
            // measures.Add("Hello");

            foreach (var measure in measures)
            {
                Console.WriteLine(measure);

                var result = (float)measure * 1.05f;
            }

        }


        private static void IfTest()
        {
            int x = 15;

            int response = x > 10 ? 10 : x;

            // ekwiwalent

            if (x > 10)
                response = 10;
            else
                response = x;
        }

        private static void LoadFileTest()
        {
            // Załadowanie całego pliku do zmiennej tekstowej
            string content = File.ReadAllText("sample1.csv");

            Console.WriteLine(content);

            // Przetwarzanie linia po linii
            var lines = File.ReadAllLines("sample1.csv");

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static void InterfaceTest()
        {
            List<IAnalogInput> devices = new List<IAnalogInput>
                {
                    new N30H(),
                    new Siemens(),
                    new Siemens()
                };



            while (true)
            {

                foreach (IAnalogInput device in devices)
                {
                    var result = device.Get(15);
                    Console.WriteLine(result);

                    Thread.Sleep(1000);
                }


            }
        }

        private static void ArrayTest()
        {
            // Utworzenie tablicy o podanej ilości elementów
            int[] values = new int[4];

            values[0] = 10;
            values[2] = 255;

            // Wyświetlenie wybranej wartości elementu
            Console.WriteLine(values[2]);

            // Wyświetlenie tablicy jako ciągu tekstowego
            var message = String.Join(", ", values);
            Console.WriteLine(message);

            // Przejście po wszystkich elementach tablicy
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }

            // Utworzenie tablicy za pomocą inicjalizatora

            int[] weights = { 20, 0, 255, 0 };
        }

        private static void VarTest()
        {
            var x = "Hello";

            x = "Hello";

            var device = new Device
            {
                SlaveId = 2,
                Manufacture = "Siemens",
                Model = "PD8",
                SerialNumber = "S/N 001",
            };
        }

        private static void AnonymuseType()
        {
            // Typ anonimowy
            var device2 = new { DeviceId = 10, Model = "Siemens" };
        }

        private static void InitTest()
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
        }

        private static void MethodsTest()
        {
            Calculator.Print(100);

            var result2 = Calculator.Add(10, 20);

            Calculator calculator = new Calculator();
            // int result = calculator.Add(10, 20);

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
