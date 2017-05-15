using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.PowerUnit.Models;
using WZL.Services;

namespace WZL.MockServices
{
    public class FileMeasuresService : IMeasuresService
    {
        private string filename;

        public FileMeasuresService(string filename)
        {
            this.filename = filename;
        }

        public void Add(Measure measure)
        {
            // Utworzenie nagłówka
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, "MeasureDate, Voltage, Current, Power");
                File.AppendAllText(filename, Environment.NewLine);
            }

            // Dopisuje do istniejącego pliku lub tworzy nowy
            using (var stream = File.AppendText(filename))
            {
                stream.WriteLine($"{measure.MeasureDate}, {measure.Voltage.ToString(CultureInfo.InvariantCulture)}, {measure.Current.ToString(CultureInfo.InvariantCulture)}, {measure.Power.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }
}
