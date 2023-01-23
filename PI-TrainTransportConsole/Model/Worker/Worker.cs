using PI_TrainTransportConsole.Model.Interface;
using PI_TrainTransportConsole.Model.Train;
using PI_TrainTransportConsole.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Worker
{
    public class Worker
    {
        public decimal Fee { get; private set; }
        public decimal TotalProfit { get; private set; }
        public string Name { get; set; }

        public Worker(string name, decimal fee)
        {
            Fee = fee;
            Name = name;
        }

        public void Refuel(IFuelable fuleable)
        {
            fuleable.RefuelToPercentage(100.0M);
        }
        public void EmbarkToTrain(SmallCommercialMotorVehicle vehicle, SmallTrain train)
        {
            train.Embark(vehicle);
            TotalProfit += vehicle.CalculateCharge() * Fee;
        }
        public void EmbarkToTrain(LargeCommercialMotorVehicle vehicle, LargeTrain train)
        {
            train.Embark(vehicle);
            TotalProfit += vehicle.CalculateCharge() * Fee;
        }
    }
}
