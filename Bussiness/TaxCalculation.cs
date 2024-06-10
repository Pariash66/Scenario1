
using congestion.calculator;
using congestion.calculator.Bussiness;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace congestion_tax_calculator_bussiness
{
    public class TaxCalculation: ITaxCalculation
    {
        private Vehicle _Vehicle;
        private DateTime[] _Date;
       
        

        public TaxCalculation(Vehicle vehicle, DateTime[] dates)
        {
            _Vehicle = vehicle;
            _Date = dates;
            
         
        }
        public int GetTax()
        {
            DateTime intervalStart = _Date[0];
            int totalFee = 0;
            int tempFee = 0;
                   foreach (DateTime date in _Date)
            {
                //int nextFee = GetTollFee(date, vehicle);
                GetTollFee getTollFee = new GetTollFee( _Vehicle, date);

                TimeSpan diffInMillies = date - intervalStart;
                double minutes = diffInMillies.TotalMinutes;

                if (minutes <= SingleChargeMinute.singleChargeMin)
                {
                    int Fee = getTollFee.IsTollFeeFunc();
                    tempFee = Math.Max(Fee, tempFee);
                }
                else
                {

                    intervalStart = date;

                    totalFee += tempFee;
                    tempFee = 0;
                }
            }
            totalFee += tempFee;

            return Math.Max(totalFee, MaxCharge.MaxChargeFee); 
        }

       
       


      
      
    }
}
