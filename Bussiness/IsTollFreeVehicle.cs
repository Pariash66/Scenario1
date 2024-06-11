
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static congestion.calculator.Bussiness.TollFreeVehicle;
using congestion.calculator.DataModel;

namespace congestion_tax_calculator_bussiness
{
    public class IsTollFreeVehicle : IIsTollFreeVehicle
    {
        
        private readonly IVehicle _vehicle;
        public IsTollFreeVehicle( IVehicle vehicle)
        {
            
            _vehicle = vehicle;

        }
        public bool IsTollFreeVehicleFunc()
        {
            try
            {
                if (_vehicle == null) return false;

                int vehicleType = _vehicle.GetVehicleType();
                return vehicleType.Equals(TollFreeVehicles.Motorcycles.ToString()) ||

                       vehicleType.Equals(TollFreeVehicles.Emergency.ToString()) ||
                       vehicleType.Equals(TollFreeVehicles.Diplomat.ToString()) ||
                       vehicleType.Equals(TollFreeVehicles.Foreign.ToString()) ||
                       vehicleType.Equals(TollFreeVehicles.Military.ToString()) ||
                        vehicleType.Equals(TollFreeVehicles.Busses.ToString());
            }
            catch (Exception ex) { throw; }

        }

    }

}
