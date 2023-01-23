using PI_TrainTransportConsole.Model.Interface;
using PI_TrainTransportConsole.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Train
{
    internal class LargeTrain : AbstractTrain, ICommercialVehicleAddable<LargeCommercialMotorVehicle>
    {
        public override int VehicleCapacity { get; } = 6;

        public bool Add(LargeCommercialMotorVehicle commercialVehicle)
        {
            if (this.ChargableVehicles.Count == VehicleCapacity)
                return false;
            this.ChargableVehicles.Add(commercialVehicle);
            return true;
        }
    }
}
