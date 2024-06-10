using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Bussiness
{
    public class HourTollFee
    {
        public int _hour;
        public int _minute;
        public   HourTollFee(int hour,int minute) {
            _hour = hour;
            _minute = minute;
      

        }
        public int CalculateFee()
        {
            if (_hour == 6 && _minute >= 0 && _minute <= 29) return 8;
            else if (_hour == 6 && _minute >= 30 && _minute <= 59) return 13;
            else if (_hour == 7 && _minute >= 0 && _minute <= 59) return 18;
            else if (_hour == 8 && _minute >= 0 && _minute <= 29) return 13;
            else if (_hour >= 8 && _hour <= 14 && _minute >= 30 && _minute <= 59) return 8;
            else if (_hour == 15 && _minute >= 0 && _minute <= 29) return 13;
            else if (_hour == 15 && _minute >= 0 || _hour == 16 && _minute <= 59) return 18;
            else if (_hour == 17 && _minute >= 0 && _minute <= 59) return 13;
            else if (_hour == 18 && _minute >= 0 && _minute <= 29) return 8;
            else return 0;
        }
    }
}
