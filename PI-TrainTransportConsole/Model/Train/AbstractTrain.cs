using PI_TrainTransportConsole.Model.Interface;
using PI_TrainTransportConsole.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Train
{
    internal abstract class AbstractTrain
    {
        public abstract int VehicleCapacity { get; }
        public ICollection<ITransportChargable> ChargableVehicles { get; set; }
    }
}
