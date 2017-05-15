using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.PowerUnit.Models
{
    public class Measure : Base
    {
        public int MeasureId { get; set; }

        public DateTime MeasureDate { get; set; }

        #region Voltage

        private float voltage;

        public float Voltage
        {
            get { return voltage; }
            set
            {
                voltage = value;

                OnPropertyChanged(nameof(Voltage));
            }
        }

        #endregion

        #region Current

        private float current;

        public float Current
        {
            get { return current; }
            set
            {
                current = value;
                OnPropertyChanged(nameof(Current));
            }
        }

        #endregion

        #region Power

        private float power;

        public float Power
        {
            get { return power; }
            set
            {
                power = value;
                OnPropertyChanged(nameof(Power));
            }
        }

        #endregion

        public Measure()
        {

        }

        public Measure(DateTime measureDate, float voltage, float current, float power)
        {
            this.MeasureDate = measureDate;
            this.Voltage = voltage;
            this.Current = current;
            this.Power = power;
        }

    }
}
