using PI_TrainTransportConsole.Model.Train;
using PI_TrainTransportConsole.Model.Train.TrainFactory;
using PI_TrainTransportConsole.Model.Vehicle;
using PI_TrainTransportConsole.Model.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole
{
    internal class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            //Create 2 workers
            Worker peroperic = new Worker("Pero Perić", 0.1M);
            Worker majamajic = new Worker("Maja Majić", 0.11M);

            //List of workers
            IList<Worker> workers = new List<Worker>() { peroperic, majamajic };

            //Random number of vehicles that will visit the train terminal
            int numberOfVehicleToVisitTheTerminal = random.Next(50,101);

            //List of trains that were loaded at max capacity and left the terminal
            IList<AbstractTrain> trainsThatLeft = new List<AbstractTrain>();

            //Current small train that is being embarked
            SmallTrain currentSmallTrain = TrainFactory.CreateTrain<SmallTrain>();

            //Current large train that is being embarked
            LargeTrain currentLargeTrain = TrainFactory.CreateTrain<LargeTrain>();

            for (int i = 0; i < numberOfVehicleToVisitTheTerminal; i++)
            {
                Console.WriteLine("[Terminal]: new vehicle entered the terminal");
                //Worker that will embark the vehicle
                Worker workerThatWillEmbarkCurrentVehicle = workers[random.Next(0, workers.Count)];
                Console.WriteLine($"[Terminal]: {workerThatWillEmbarkCurrentVehicle.Name} will embark te vehicle to the train");
                //Random fuel percentage that will be in the next vehicle
                decimal initialFuelPercentage = (decimal)(random.NextDouble() * 100.0);
                int randomVehicleOption = random.Next(0, 2);

                //Small motor vehicle appears at the terminal
                if (randomVehicleOption == 0)
                {
                    SmallCommercialMotorVehicle smallCommercialMotorVehicle;
                    int randomSmallVehicleOption = random.Next(0, 3);

                    //Small vehicle is a gas car
                    if(randomSmallVehicleOption == 0)
                    {
                        Console.WriteLine("[Terminal]: Vehicle is a family car");
                        smallCommercialMotorVehicle = new GasCar(initialFuelPercentage);
                    }
                    //Electric car
                    else if (randomSmallVehicleOption == 1)
                    {
                        Console.WriteLine("[Terminal]: Vehicle is an electric family car");
                        smallCommercialMotorVehicle = new ElectricCar(initialFuelPercentage);
                    }
                    //Gas van
                    else
                    {
                        Console.WriteLine("[Terminal]: Vehicle a gas family car");
                        smallCommercialMotorVehicle = new GasVan(initialFuelPercentage);
                    }

                    if (smallCommercialMotorVehicle.FuelPercentage() < 10.0M)
                    {
                        Console.WriteLine("[Terminal]: Vehicle is low on fuel");
                        Console.WriteLine("Refuleing...");
                        Thread.Sleep(1000);
                    }

                    //Woker embarks the current small vehicle to train
                    workerThatWillEmbarkCurrentVehicle.EmbarkToTrain(smallCommercialMotorVehicle, currentSmallTrain);
                    Console.WriteLine("[Terminal]: Embarked on the train!");
                }
                //Same, but large vehicle appears.
                else
                {
                    LargeCommercialMotorVehicle largeCommercialMotorVehicle;
                    int randomSmallVehicleOption = random.Next(0, 2);
                    if (randomSmallVehicleOption == 0)
                    {
                        Console.WriteLine("[Terminal]: Vehicle is an bus");
                        largeCommercialMotorVehicle = new GasBus(initialFuelPercentage);
                    }
                    else
                    {
                        Console.WriteLine("[Terminal]: Vehicle is a truck");
                        largeCommercialMotorVehicle = new GasTruck(initialFuelPercentage);
                    }

                    if (largeCommercialMotorVehicle.FuelPercentage() < 10.0M)
                    {
                        Console.WriteLine("[Terminal]: Vehicle is low on fuel");
                        Console.WriteLine("Refuleing...");
                        Thread.Sleep(1000);
                    }

                    workerThatWillEmbarkCurrentVehicle.EmbarkToTrain(largeCommercialMotorVehicle, currentLargeTrain);
                    Console.WriteLine("[Terminal]: Embarked on the train!");
                }

                //Last iteration of the loop, both current trains leave, no matter the capacity.
                if(i == numberOfVehicleToVisitTheTerminal - 1)
                {
                    trainsThatLeft.Add(currentSmallTrain);
                    trainsThatLeft.Add(currentLargeTrain);
                    Console.WriteLine("[Terminal]: End of the day. Sending the remaining trains...");
                }

                //It's not the last iteration
                else
                {
                    if (currentLargeTrain.MaxCapacity())
                    {
                        trainsThatLeft.Add(currentLargeTrain);
                        currentLargeTrain = TrainFactory.CreateTrain<LargeTrain>();
                        Console.WriteLine("[Terminal]: Large train at max capacity. Sending current and bringin next.");
                    }
                    if (currentSmallTrain.MaxCapacity())
                    {
                        trainsThatLeft.Add(currentSmallTrain);
                        currentSmallTrain = TrainFactory.CreateTrain<SmallTrain>();
                        Console.WriteLine("[Terminal]: Small train at max capacity. Sending current and bringin next.");
                    }
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine($"Total vehicles that visited the terminal: {numberOfVehicleToVisitTheTerminal}");
            Console.WriteLine($"Total trains that left: {trainsThatLeft.Count}");
            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Name} made {worker.TotalProfit} profit today.");
            }
        }
    }
}
