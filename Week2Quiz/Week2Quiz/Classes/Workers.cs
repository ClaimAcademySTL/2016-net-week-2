using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Quiz.Classes
{
    class Workers : Task
    {
        private string _fName, _lName, _dOB, _gender;
        private int _idNum;

        public Workers (string fName,string lName,int idNum,string dOB,string gender)
        {
            //more inheritance things
            _fName = fName;
            _lName = lName;
            _dOB = dOB;
            _gender = gender;
            _idNum = idNum;
        }

        public void Execute()
        {
            //something else that is probably important
        }
    }
}
