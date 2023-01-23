using Microsoft.VisualStudio.TestTools.UnitTesting;
using PI_TrainTransportConsole.Model.Train;
using PI_TrainTransportConsole.Model.Train.TrainFactory;
using PI_TrainTransportConsole.Model.Vehicle;
using PI_TrainTransportConsole.Model.Worker;
using System;

namespace PI_UnitTests
{
    [TestClass]
    public class TrainTransportTesting
    {
        [TestMethod]
        public void TestWorkerProfit()
        {
            decimal expectedProfit = 5M;
            Worker worker = new Worker("Test Worker", 0.1M);
            SmallTrain train = TrainFactory.CreateTrain<SmallTrain>();
            SmallCommercialMotorVehicle vehicle = new GasCar(34.0M);
            worker.EmbarkToTrain(vehicle, train);
            decimal profit = worker.TotalProfit;
            Assert.AreEqual(profit, expectedProfit);
        }
    }
}
