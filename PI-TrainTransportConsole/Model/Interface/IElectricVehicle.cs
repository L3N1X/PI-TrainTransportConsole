﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Interface
{
    internal interface IElectricVehicle
    {
        decimal MaxBatteryCapacityAh { get; }
        decimal CurrentBatteryCapacityAh { get; }
    }
}
