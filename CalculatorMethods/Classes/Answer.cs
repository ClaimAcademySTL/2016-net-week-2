using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Answer
    {
        private Boolean inBounds;
        private double answer, tempDouble;

        private void printAnswer(string[] operSymbols, double[] numberArray)
        {
            answer = getAnswer(operSymbols, numberArray);
            if (inBounds)
            {
                for (int r = 0; r < numberArray.Length; r++)
                {
                    if (r < operSymbols.Length)
                    {
                        Console.WriteLine(numberArray[r] + " " + operSymbols[r]);
                    }
                    else
                    {
                        Console.WriteLine(numberArray[r] + "\n=" + answer);
                    }
                }
            }
            else
            {
                Console.WriteLine("Oops, you went out of bounds.");
            }
        }

        private double getAnswer(string[] oper, double[] numArray)
        {

            
            tempDouble = numArray[0];

            inBounds = true;

            for (int x = 1; x < numArray.Length; x++)
            {
                Evaluate temp = new Evaluate();
                tempDouble = temp.evalExpression(oper[x - 1], tempDouble, numArray[x], out inBounds);
                if (!inBounds)
                {
                    inBounds = false;
                    break;
                }
            }
            return tempDouble;
        }
    }
}
