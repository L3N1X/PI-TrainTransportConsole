using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Interface
{
    public interface IFuelable
    {
        decimal FuelPercentage();
        void RefuelToPercentage(decimal percentageAfterFuel);
    }
}
