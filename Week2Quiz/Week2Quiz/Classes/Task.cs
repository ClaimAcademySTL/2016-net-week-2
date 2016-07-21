using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz.Classes
{
    class Task : Clock
    {
        private string _startTime, _duration, _description;


        public Task(string startTime,string duration,string description)
        {
            //inheritance things
            _startTime = startTime;
            _duration = duration;
            _description = description;
        }

        public void Execute()
        {
            //something important
        }
    }
}
