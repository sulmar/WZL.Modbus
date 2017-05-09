using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.SampleApp
{
    class Siemens : IAnalogInput, IAnalogOutput
    {
        public float Get(byte slaveId)
        {
            return 230;
        }

        public void Set(float value)
        {
            
        }
    }

    class N30H : IAnalogInput
    {
        public float Get(byte slaveId)
        {
            return 100.5f;
        }

       

        public void On()
        {

        }

        public void Off()
        {

        }
    }
}
