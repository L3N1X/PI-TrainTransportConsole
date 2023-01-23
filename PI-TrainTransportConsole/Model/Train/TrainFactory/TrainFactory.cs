using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Train.TrainFactory
{
    internal static class TrainFactory
    {
        public static T CreateTrain<T>() where T : AbstractTrain, new()
        {
            return new T();
        }
    }
}
