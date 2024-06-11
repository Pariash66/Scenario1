using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static congestion.calculator.DataModel.VehicleTypes;

namespace congestion.calculator.DataModel
{
    public class Diplomat : IVehicle
    {


        public int GetVehicleType()
        {
            return (int)vehicleType.Diplomat;
        }
    }
}