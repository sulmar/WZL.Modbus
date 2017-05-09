using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.CSharp.SampleApp
{
    interface IAnalogInput
    {
        float Get(byte slaveId);

        // void Set(float value);

    }

    interface IAnalogOutput
    {
        void Set(float value);

    }
}
