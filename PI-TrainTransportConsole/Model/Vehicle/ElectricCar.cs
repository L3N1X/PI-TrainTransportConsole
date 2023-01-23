using PI_TrainTransportConsole.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Vehicle
{
    public class ElectricCar : SmallCommercialMotorVehicle, IElectricVehicle
    {
        public ElectricCar(decimal intialFuelPercentage) : base(intialFuelPercentage)
        {
            RefuelToPercentage(intialFuelPercentage);
        }

        public decimal MaxBatteryCapacityAh => 4.8M;

        public decimal CurrentBatteryCapacityAh { get; set; } = 0.0M;

        public override decimal CalculateCharge()
        {
            return 50.0M;
        }

        public override decimal FuelPercentage()
        {
            return CurrentBatteryCapacityAh / MaxBatteryCapacityAh * 100;
        }

        public override void RefuelToPercentage(decimal percentageAfterFuel)
        {
            if (percentageAfterFuel > 100.0M)
                percentageAfterFuel = 100.0M;
            CurrentBatteryCapacityAh = (percentageAfterFuel / 100.0M) * CurrentBatteryCapacityAh;
        }
    }
}
