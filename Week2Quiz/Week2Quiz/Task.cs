using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz
{
    class Task
    {
        public int StartTime { get { return _startTime; } }
        public String Duration { get { return _duration; } }
        public String Description { get; set; }

        private int _startTime;
        private String _duration = null;

        public Task(String desc)
        {
            Description = desc;
        }

        public void Execute()
        {
            Clock timer = new Clock(false);
            _startTime = GetTime();
            timer.Start();
            DoStuff();
            timer.Stop();
            _duration = timer.ElapsedTime;

        }

        private void DoStuff()
        {
            // Do whatever a task does
        }
    }
}
