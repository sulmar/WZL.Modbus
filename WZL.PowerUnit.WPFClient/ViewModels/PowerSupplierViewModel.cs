using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.PowerUnit.WPFClient.ViewModels
{
    public class PowerSupplierViewModel
    {
        public float Voltage { get; set; }

        public float Current { get; set; }

        public float Power { get; set; }

        public PowerSupplierViewModel()
        {
            Voltage = 2.4f;

            Current = 3.0f;

            Power = 15.0f;
        }

    }
}
