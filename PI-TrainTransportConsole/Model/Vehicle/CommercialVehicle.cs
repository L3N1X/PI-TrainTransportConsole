﻿using PI_TrainTransportConsole.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_TrainTransportConsole.Model.Vehicle
{
    internal abstract class CommercialVehicle : ITransportChargable
    {
        public abstract decimal CalculateCharge();
    }
}
