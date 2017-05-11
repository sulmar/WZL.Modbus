using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Threading;
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



        private float current;

        public float Current
        {
            get { return current; }
            set
            {
                current = value;
                OnPropertyChanged("Current");
            }
        }

        // ObservableCollection - lista, która wysyła zdarzenie (sygnał) INotifyCollectionChanged 
        // przy dodaniu lub usunięciu elementu do listy

        private object _lock = new object();

        private ObservableCollection<float> voltages;

        public ObservableCollection<float> Voltages
        {
            get { return voltages; }

            set
            {
                voltages = value;
                BindingOperations.EnableCollectionSynchronization(voltages, _lock);

                OnPropertyChanged("Voltages");
            }
        }


        public float Power { get; set; }

        private IAnalogInput VoltageService;
        private IAnalogInput CurrentService;

        private Timer timer;

        public PowerSupplierViewModel()
        {
            VoltageService = new N30HVoltageService();
            CurrentService = new N30UCurrentService();

            Voltages = new ObservableCollection<float>();

            timer = new Timer(1000);

            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Voltage = VoltageService.Get();
            Current = CurrentService.Get();

           Voltages.Add(Voltage);
        }
    }
}
