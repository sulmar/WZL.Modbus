using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.MockServices;
using WZL.Services;

namespace WZL.PowerUnit.WPFClient.ViewModels
{
    public class PowerSupplierViewModel
    {
        public float Voltage { get; set; }

        public float Current { get; set; }

        public float Power { get; set; }

        private IAnalogInput VoltageService;

        public PowerSupplierViewModel()
        {
            VoltageService = new MockVoltageService();

            Voltage = VoltageService.Get();
        }

    }
}
