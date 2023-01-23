using PI_TrainTransportConsole.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Interface
{
    public interface ICommercialVehicleAddable<T> where T : CommercialVehicle
    {
        bool Embark(T commercialVehicle);
    }
}
