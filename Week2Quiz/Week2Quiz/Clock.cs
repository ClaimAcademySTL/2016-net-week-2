using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz
{
    class Clock
    {
        public String ElapsedTime
        {
            get
            {
                if (_hasCompleted)
                {
                    String unit = getAppropriateUnit(_elapsedTimeMs);
                    return String.Format("{0} {1}", ConvertFromMillis(_elapsedTimeMs, unit), unit);
                }
                else
                {
                    return null;
                }
            }
        }

        public String Units
        {
            get
            {
                return getAppropriateUnit(_elapsedTimeMs);
            }
        }

        private int _elapsedTimeMs = 0;
        private int _startTimeMs;
        private bool _isRunning = false;
        private bool _hasCompleted = false;

        public Clock(bool startImmediately = false)
        {
            if (startImmediately)
            {
                Start();
            }
        }

        public void Start()
        {
            _isRunning = true;
            _hasCompleted = false;
            _startTimeMs = GetTime();   // GetTime is not implemented, but gets current time in milliseconds
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _elapsedTimeMs = GetTime() - _startTimeMs;
                _isRunning = false;
                _hasCompleted = true;
            }
        
        }

        private String getAppropriateUnit(int millis)
        {
            if (millis < 1000)
            {
                return "Milliseconds";
            }
            else if (millis < 1000 * 60)
            {
                return "Seconds";
            }
            // et cetera, for larger units

            else
            {
                return String.Empty;
            }
        }

        private double ConvertFromMillis(int millis, String unit)
        {
            switch (unit)
            {
                case "Milliseconds":
                    return millis;

                case "Seconds":
                    return millis / 1000.0;

                // Other cases for other units

                default:
                    return 0;
            }
        }
    }
}
