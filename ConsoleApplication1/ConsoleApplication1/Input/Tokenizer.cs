using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class Tokenizer
    {
        public char Splitter
        {
            get { return _splitterArray[0]; }
            set { _splitterArray[0] = value; }
        }

        private char[] _splitterArray = new char[1];

        public Tokenizer(char splitter = ' ')
        {
            Splitter = splitter;
        }

        

        public String[] Tokenize(String inputString)
        {
            return inputString.Split(_splitterArray, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
