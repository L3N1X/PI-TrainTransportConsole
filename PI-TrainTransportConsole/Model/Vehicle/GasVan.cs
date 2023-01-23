using PI_TrainTransportConsole.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Vehicle
{
    public class GasVan : SmallCommercialMotorVehicle, IGasVehicle
    {
        public GasVan(decimal intialFuelPercentage) : base(intialFuelPercentage)
        {
            RefuelToPercentage(intialFuelPercentage);
        }

        public decimal MaxGasCapacityL => 50.0M;

        public decimal CurrentGasCapacityL { get; set; } = 0.0M;

        public override decimal CalculateCharge()
        {
            return 80.0M;
        }

        public override decimal FuelPercentage()
        {
            return CurrentGasCapacityL / MaxGasCapacityL * 100;
        }

        public override void RefuelToPercentage(decimal percentageAfterFuel)
        {
            if (percentageAfterFuel > 100.0M)
                percentageAfterFuel = 100.0M;
            CurrentGasCapacityL = (percentageAfterFuel / 100.0M) * MaxGasCapacityL;
        }
    }
}
