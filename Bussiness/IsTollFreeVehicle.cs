
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using congestion.calculator;

namespace congestion_tax_calculator_bussiness
{
    public class IsTollFreeVehicle : IIsTollFreeVehicle
    {
        
        private readonly Vehicle _vehicle;
        public IsTollFreeVehicle( Vehicle vehicle)
        {
            
            _vehicle = vehicle;

        }
        public bool IsTollFreeVehicleFunc()
        {
            if (_vehicle == null) return false;

            //String vehicleType = _vehicle.GetVehicleType();
            //return vehicleType.Equals(TollFreeVehicle.Motorcycle.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Tractor.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
            //       vehicleType.Equals(TollFreeVehicles.Military.ToString()||
            //        vehicleType.Equals(TollFreeVehicles.busses.ToString());
            return true;

        }

    }

}
