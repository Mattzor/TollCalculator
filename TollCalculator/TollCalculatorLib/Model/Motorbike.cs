﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Model
{
    public class Motorbike : IVehicle
    {
        public VehicleType GetVehicleType() => VehicleType.Motorbike;
    }
}
