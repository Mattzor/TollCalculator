using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Model
{
    public class Car : IVehicle
    {
        public VehicleType GetVehicleType() => VehicleType.Car;

    }
}
