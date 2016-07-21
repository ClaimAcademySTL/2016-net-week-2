using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class InputList
    {
        private List<string> operatorChars;
        private int _numberOfNums;
        private List<double> numDoubles;
        
        public InputList(int numberOfNums)
        {
            this._numberOfNums = numberOfNums;
        }

        public List<string> GetOperatorChars()
        {
            for(int x = 0; x < _numberOfNums - 1; x++)
            {
                operatorChars.Add(Input.GetOperator());
            }
            return operatorChars;
        }

        public List<double> GetNums()
        {
            for(int y = 0; y < _numberOfNums; y++)
            {
                numDoubles.Add(Input.GetDouble());
            }
            return numDoubles;
        }
        
         
    }
}
