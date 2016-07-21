using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz.Classes
{
    class Clock
    {
        //see awful things below
        string units;
        private int milliseconds, seconds, minutes, hours, days;

        public Clock()
        {
            milliseconds = 0;
            seconds = 0;
            minutes = 0;
            hours = 0;
            days = 0;
        }

        public void Start()
        {
            //starts clock
        }

        public void Stop()
        {
            //stops clock
        }

        public string PrintElapsed()
        {
            units = System.String.Format("Elapsed time is {0} days {1} hours {2} minutes {3} seconds and {4} milliseconds",days,hours,minutes,seconds,milliseconds);
            return units;
        }
    }

    interface ElapsedTime
    {
        int milliseconds
        {
            get;
            set;
        }

        int seconds
        {
            get;
            set;
        }
        int minutes
        {
            get;
            set;
        }

        int hours
        {
            get;
            set;
        }
        int days
        {
            get;
            set;
        }
    }
}
