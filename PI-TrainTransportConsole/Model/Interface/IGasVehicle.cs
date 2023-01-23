using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Interface
{
    internal interface IGasVehicle
    {
        decimal MaxGasCapacityL { get; }
        decimal CurrentGasCapacityL { get; set; }
    }
}
