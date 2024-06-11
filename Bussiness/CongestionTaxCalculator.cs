using System;
using System.Collections.Generic;
using congestion.calculator.Bussiness;
using congestion.calculator.DataModel;
using congestion_tax_calculator_bussiness;
public class CongestionTaxCalculator : ICongestionTaxCalculator
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private readonly IVehicle _vehicle;
    private readonly DateTime[] _Date;
    public CongestionTaxCalculator(IVehicle vehicle, DateTime[] date)
    {
        _Date = date;
        _vehicle = vehicle;
    }
    public int GetTax()
    {
        DateTime intervalStart = _Date[0];
        int totalFee = 0;
        int tempFee = 0;
              foreach (DateTime date in _Date)
        {
            //int nextFee = GetTollFee(date, vehicle);
            GetTollFee getTollFee = new GetTollFee(_vehicle, date);

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

        return Math.Max(totalFee, CMaxCharge.Maxcharge); ;
    }

}