using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz
{
    class Worker
    {
        
        public String FirstName { get { return _firstName; } }
        public String LastName { get { return _lastName; } }
        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
        public String ReversedName { get { return String.Format("{0}, {1}", LastName, FirstName); } }
        public long Id { get { return _id; } }
        public int BirthYear { get { return _birthYear; } }
        public int BirthMonth { get { return _birthMonth; } }
        public int BirthDayOfMonth { get { return _birthDay; } }
        public char Gender { get { return _gender; } }

        private readonly String _firstName;
        private readonly String _lastName;
        private readonly long _id;
        private readonly int _birthYear;
        private readonly int _birthMonth;
        private readonly int _birthDay;
        private readonly char _gender;

        private Task _task;



        public Worker(String firstName, String lastName, long id, int birthYear, int birthMonth, int birthDayOfMonth, char gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _id = id;
            _birthYear = birthYear;
            _birthMonth = birthMonth;
            _birthDay = birthDayOfMonth;
            _gender = gender;

            _task = null;
        }

        public bool GiveTask(Task newTask)
        {
            if (_task == null)
            {
                _task = newTask;
                return true;
            }
            else
            {
                // I already have a task!
                return false;
            }
        }

        public void ExecuteTask(Task task = null)
        {
            if (task != null)
            {
                // This is high priority, so forget any old tasks
                _task = task;
            }

            if (_task == null)
            {
                // I don't have any task, and you didn't give me a new one!
                return;
            }

            _task.Execute();
        }

    }
}
