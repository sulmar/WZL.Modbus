using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WZL.LumelServices;
using WZL.MockServices;
using WZL.Services;

namespace WZL.PowerUnit.WPFClient.ViewModels
{
    public class PowerSupplierViewModel : BaseViewModel
    {

        private float voltage;

        public float Voltage
        {
            get { return voltage; }
            set
            {
                voltage = value;

                OnPropertyChanged("Voltage");
            }
        }



        public float Current { get; set; }

        public float Power { get; set; }

        private IAnalogInput VoltageService;

        private Timer timer;

        public PowerSupplierViewModel()
        {
            VoltageService = new N30HVoltageService();

            timer = new Timer(1000);

            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Voltage = VoltageService.Get();
        }
    }
}
