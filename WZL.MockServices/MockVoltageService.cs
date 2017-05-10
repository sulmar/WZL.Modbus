using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.Services;

namespace WZL.MockServices
{
    public class MockVoltageService : IAnalogInput
    {
        public float Get()
        {
            return 5.2f;
        }
    }
}
