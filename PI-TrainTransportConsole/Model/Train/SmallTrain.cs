using PI_TrainTransportConsole.Model.Interface;
using PI_TrainTransportConsole.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Train
{
    internal class SmallTrain : AbstractTrain, ICommercialVehicleAddable<SmallCommercialMotorVehicle>
    {
        public override int VehicleCapacity { get; } = 8;

        public bool Add(SmallCommercialMotorVehicle commercialVehicle)
        {
            if (this.ChargableVehicles.Count == VehicleCapacity)
                return false;
            this.ChargableVehicles.Add(commercialVehicle);
            return true;
        }
    }
}
