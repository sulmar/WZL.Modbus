using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.SampleApp
{
    public class LumelVoltage
    {

        public float Get()
        {
            // TODO: obsługa modbus + lumel

            return 100.3f;
        }

        public void Set(float voltage)
        {
            // TODO: obsługaa modbus + lumel


        }

        public void On(bool value)
        {

        }
    }

    public class SiemensVoltage
    {
        public float Get()
        {
            // TODO: obsługa modbus + siemens

            return 10.3f;
        }

        public void Set(float voltage)
        {
            // TODO: obsługaa modbus + siemens


        }
    }
}
