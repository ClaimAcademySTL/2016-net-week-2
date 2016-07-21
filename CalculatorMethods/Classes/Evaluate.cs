using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Evaluate : Boundary
    {
        public double evalExpression(string op, double fNum, double sNum, out Boolean checkBound)
        {
            switch (op)
            {
                case "+":
                    if (CheckAddBound(fNum, sNum))
                    {
                        checkBound = true;
                        return AddNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "-":
                    if (CheckSubBound(fNum, sNum))
                    {
                        checkBound = true;
                        return SubNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "/":
                    if (CheckDivBound(fNum, sNum))
                    {
                        checkBound = true;
                        return DivNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "*":
                    if (CheckMultBound(fNum, sNum))
                    {
                        checkBound = true;
                        return MultNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                default:
                    Console.WriteLine("I guess I suck at programming.");
                    checkBound = false;
                    return 0;
                    break;
            }
        }

        private static double AddNums(double fNum, double sNum)
        {
            return fNum + sNum;
        }

        private static double SubNums(double fNum, double sNum)
        {
            return fNum - sNum;
        }

        private static double DivNums(double fNum, double sNum)
        {
            return fNum / sNum;
        }

        private static double MultNums(double fNum, double sNum)
        {
            return fNum * sNum;
        }
    }
}
