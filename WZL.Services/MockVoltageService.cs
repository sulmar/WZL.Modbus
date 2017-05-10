using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.Services
{
    public class MockVoltageService : IAnalogInput
    {
        public float Get()
        {
            return 5.2f;
        }
    }
}
