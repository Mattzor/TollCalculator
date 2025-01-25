using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculatorLib.Model
{
    public interface IVehicle
    {   
        VehicleType GetVehicleType();
    }

    public enum VehicleType
    {
        Car,
        Motorbike,
        Tractor,
        Emergency,
        Diplomat,
        Foreign,
        Military
    }
}
