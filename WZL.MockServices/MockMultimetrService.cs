using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WZL.Services;

namespace WZL.MockServices
{
    public class MockMultimetrService : IVoltageInputService, ICurrentInputService, IBinaryService
    {
        public bool[] Get()
        {
            throw new NotImplementedException();
        }

        public void Set(bool[] outputs)
        {
            throw new NotImplementedException();
        }

        float ICurrentInputService.Get()
        {
            throw new NotImplementedException();
        }

        float IVoltageInputService.Get()
        {
            return 220;
        }


     
    }
}
