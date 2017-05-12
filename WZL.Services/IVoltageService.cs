using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WZL.Services
{

    public interface IVoltageInputService
    {
        float Get();
    }

    public interface IVoltageOutputService
    {
        void Set(float value);
    }

    public interface ICurrentInputService
    {
        float Get();

    }

    public interface ICurrentOutputService
    {
        void Set(float value);

        
    }

    public interface IOutputService
    {
        void On();

        void Off();

        bool IsOn();
    }

    public interface IPowerService
    {
        float Get();
    }

    public interface IBinaryService
    {
        bool[] Get();

        void Set(bool[] outputs);
    }
}
