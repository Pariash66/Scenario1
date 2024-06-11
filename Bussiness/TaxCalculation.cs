using congestion.calculator.Bussiness;
using congestion.calculator.DataModel;
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
        private IVehicle _Vehicle;
        private DateTime[] _Date;
       
        

        public TaxCalculation(IVehicle vehicle, DateTime[] dates)
        {
            _Vehicle = vehicle;
            _Date = dates;
            
         
        }
        public int GetTax()
        {
            try
            {
                Array.Sort(_Date);

                DateTime intervalStart = _Date[0];
                int totalFee = 0;
                int tempFee = 0;
                int PrevFee = 0;
                foreach (DateTime date in _Date)
                {
                    //int nextFee = GetTollFee(date, vehicle);
                    GetTollFee getTollFee = new GetTollFee(_Vehicle, date);

                    TimeSpan diffInMillies = date - intervalStart;
                    double minutes = diffInMillies.TotalMinutes;
                    int Fee = getTollFee.IsTollFeeFunc();

                    if (minutes <= SingleChargeMinute.singleChargeMin)
                    {
                        tempFee = Math.Max(Fee, tempFee);
                        totalFee -= PrevFee;
                        PrevFee = 0;
                    }
                    else
                    {

                        intervalStart = date;
                        PrevFee = Fee;
                        totalFee += tempFee;
                        tempFee = 0;
                    }
                }
                totalFee += tempFee;

                return Math.Min(totalFee, MaxCharge.MaxChargeFee);
            }catch(Exception ex) { throw; }
        }

       
       


      
      
    }
}
