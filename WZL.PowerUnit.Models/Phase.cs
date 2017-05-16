using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.PowerUnit.Models
{
    public class Phase : Base
    {
        #region Voltage

        private float _Voltage;

        public float Voltage
        {
            get { return _Voltage; }
            set
            {
                _Voltage = value;
                OnPropertyChanged(nameof(Voltage));
            }
        }

        #endregion

        #region  Current

        private float _Current;

        public float Current
        {
            get { return _Current; }
            set {
                _Current = value;
                OnPropertyChanged(nameof(Current));
            }
        }


        #endregion


        public float ActivePower { get; set; }

        public float ReactivePower { get; set; }

        public float ApparentPower { get; set; }

        public float PowerFactor { get; set; }

        public float PhaseFactor { get; set; }
    }
}
