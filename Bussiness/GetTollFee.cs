﻿
using System;
using System.Collections.Generic;
using System.Text;
using static congestion_tax_calculator_bussiness.TaxCalculation;
using congestion.calculator;
using congestion.calculator.Bussiness;

namespace congestion_tax_calculator_bussiness
{

    public class GetTollFee : IGetTollFee
    {
        
       
        private readonly Vehicle _vehicle;
        private readonly DateTime _datetime;
        public GetTollFee(Vehicle vehicle, DateTime datetime)
        {
            
            _vehicle = vehicle;
            _datetime = datetime;
        }

        public int IsTollFeeFunc()
        {
            IsTollFreeDate freeDate = new IsTollFreeDate(_datetime);
            IsTollFreeVehicle freeVehice = new IsTollFreeVehicle(_vehicle);
            if (freeDate.isTollFreeDatefunc() || freeVehice.IsTollFreeVehicleFunc()) return 0;

            int hour = _datetime.Hour;
            int minute = _datetime.Minute;
            int? amount = 0;
            HourTollFee fee = new HourTollFee(hour, minute);
            return fee.CalculateFee();
         
        }
    }




}
