using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WZL.EAServices;
using WZL.LumelServices;
using WZL.MockServices;
using WZL.PowerUnit.Models;
using WZL.Services;

namespace WZL.PowerUnit.WPFClient.ViewModels
{
    public class PowerSupplierViewModel : BaseViewModel
    {


        #region IsPowerOn

        private bool isPowerOn;

        public bool IsPowerOn
        {
            get { return isPowerOn; }
            set
            {
                isPowerOn = value;
                OnPropertyChanged(nameof(IsPowerOn));
            }
        }

        #endregion

        #region Measure

        private Measure _Measure;
        public Measure Measure
        {
            get
            {
                return _Measure;
            }

            set
            {
                _Measure = value;
                OnPropertyChanged(nameof(Measure));
            }
        }

        #endregion


        //#region Voltage

        //private float voltage;

        //public float Voltage
        //{
        //    get { return voltage; }
        //    set
        //    {
        //        voltage = value;

        //        OnPropertyChanged(nameof(Voltage));
        //    }
        //}

        //#endregion

        //#region Current

        //private float current;

        //public float Current
        //{
        //    get { return current; }
        //    set
        //    {
        //        current = value;
        //        OnPropertyChanged(nameof(Current));
        //    }
        //}

        //#endregion

        //public float Power { get; set; }

        private float supplierVoltage;

        public float SupplierVoltage
        {
            get { return supplierVoltage; }
            set {
                supplierVoltage = value;
                OnPropertyChanged(nameof(SupplierVoltage));
            }
        }


        #region SupplierCurrent

        private float supplierCurrent;

        public float SupplierCurrent
        {
            get { return supplierCurrent; }
            set
            {
                supplierCurrent = value;
                OnPropertyChanged(nameof(SupplierCurrent));
            }
        }


        #endregion

      

        #region Voltages

        private object _lock = new object();

        // ObservableCollection - lista, która wysyła zdarzenie (sygnał) INotifyCollectionChanged 
        // przy dodaniu lub usunięciu elementu do listy

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

        #endregion


        #region SettingsCurrent

        public float SettingsCurrentLowLimit { get; } = 0;
        public float SettingsCurrentHighLimit { get; } = 60;


        private float settingsCurrent;

        public float SettingsCurrent
        {
            get { return settingsCurrent; }
            set {

                if (value < SettingsCurrentLowLimit)
                    settingsCurrent = SettingsCurrentLowLimit;
                else
              if (value > SettingsCurrentHighLimit)
                    settingsCurrent = SettingsCurrentHighLimit;
                else
                    settingsCurrent = value;

                OnPropertyChanged(nameof(SettingsCurrent));
            }
        }


        #endregion

        #region SettingsVoltage

        public float SettingsVoltageLowLimit { get; } = 0;
        public float SettingsVoltageHighLimit { get; } = 40;
        

        private float settingsVoltage;

        public float SettingsVoltage
        {
            get { return settingsVoltage; }
            set
            {
                // Walidacja zakresu
                if (value < SettingsVoltageLowLimit)
                    settingsVoltage = SettingsVoltageLowLimit;
                else
                if (value > SettingsVoltageHighLimit)
                    settingsVoltage = SettingsVoltageHighLimit;
                else
                    settingsVoltage = value;

                OnPropertyChanged(nameof(SettingsVoltage));
            }
        }

        #endregion


     

        private IAnalogInput VoltageService;
        private IAnalogInput CurrentService;

        private IVoltageOutputService VoltageOutputService;
        private ICurrentOutputService CurrentOutputService;
        private IOutputService OutputService;
        private IVoltageInputService SupplierVoltageInputService;
        private ICurrentInputService SupplierCurrentInputService;

        private Timer timer;

        #region PowerSwitchCommand

        private ICommand _PowerSwitchCommand;

        public ICommand PowerSwitchCommand
        {
            get
            {
                if (_PowerSwitchCommand == null)
                {
                    _PowerSwitchCommand = new RelayCommand(PowerSwitch);
                }

                return _PowerSwitchCommand;
            }
        }

        private void PowerSwitch()
        {
            if (IsPowerOn)
            {
                OutputService.On();
            }
            else
            {
                OutputService.Off();
            }
        }

        #endregion


        #region SetCommand

        private ICommand _SetCommand;

        public ICommand SetCommand
        {
            get
            {
                if (_SetCommand == null)
                {
                    _SetCommand = new RelayCommand(Set, CanSet);
                }

                return _SetCommand;
            }
        }

        private void Set()
        {
            VoltageOutputService.Set(SettingsVoltage);
            CurrentOutputService.Set(SettingsCurrent);
        }

        private bool CanSet()
        {

            // TODO: warunek sterowania sprzętem
            return SettingsVoltage > 0 && SettingsCurrent > 0;
        }

        #endregion

        #region SaveCommand

        private ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new RelayCommand(Save);
                }

                return _SaveCommand;
            }
        }

        private void Save()
        {
            this.Measure
            // TODO: Zapis pomiaru
        }

        #endregion

        public PowerSupplierViewModel()
        {
            VoltageService = new N30HVoltageService();
            CurrentService = new N30UCurrentService();

            VoltageOutputService = new SupplierService();
            CurrentOutputService = new SupplierService();
            OutputService = new SupplierService();
            SupplierVoltageInputService = new SupplierService();
            SupplierCurrentInputService = new SupplierService();

            Voltages = new ObservableCollection<float>();

            timer = new Timer(1000);

            timer.Elapsed += Timer_Elapsed;

            timer.Enabled = true;


        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            IsPowerOn = OutputService.IsOn();

            var voltage = VoltageService.Get();
            var current = CurrentService.Get();
            var power = 0;

            this.Measure = new Measure(DateTime.Now, voltage, current, power); 

            SupplierVoltage = SupplierVoltageInputService.Get();
            SupplierCurrent = SupplierCurrentInputService.Get();

            Voltages.Add(this.Measure.Voltage);
        }
    }
}
