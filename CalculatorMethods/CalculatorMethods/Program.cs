using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] opers;
            int quantityNums;
            double[] numsToUse;

            do
            {
                Console.WriteLine("Please enter how many numbers you would like to use in the expression.");
                quantityNums = getValidInt();
                Console.WriteLine("\n");

                numsToUse = getAllInput(quantityNums, out opers);

                printAnswer(opers, numsToUse);

                Console.WriteLine("Enter yes to run again, or no to stop");
            }while (checkContinue());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void printAnswer(string[] operSymbols, double[] numberArray)
        {
            Boolean boundary;
            double answer;

            answer = getAnswer(operSymbols, numberArray, out boundary);
            if (boundary)
            {
                for(int r = 0; r < numberArray.Length; r++)
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

        private static double [] getAllInput(int numOfNums, out string [] ops)
        {
            string[] tempOpArray = new string[numOfNums - 1];
            double[] tempNumArray = new double[numOfNums];

            for (int i = 0; i < tempNumArray.Length; i++)
            {
                Console.WriteLine("Please enter a number to use for position " + (i+1) + ".");
                tempNumArray[i] = getValidDouble();
                if (i < tempOpArray.Length)
                {
                    Console.WriteLine("Please enter an operator to use (+, -, /, *).");
                    tempOpArray[i] = getValidOp();
                }
                Console.WriteLine("\n");
            }
            ops = tempOpArray;
            return tempNumArray;
        }

        private static int getValidInt()
        {
            Boolean validNum = true;
            string inpValue;
            int tempNum;

            do
            {
                if (!validNum)
                {
                    Console.WriteLine("Invalid entry, enter a valid positive integer.");
                }
                inpValue = Console.ReadLine();
                validNum = int.TryParse(inpValue, out tempNum);
                if(validNum && tempNum <= 0)
                {
                    validNum = false;
                }
            } while (!validNum);

            return tempNum;
        }

        private static double getValidDouble()
        {
            Boolean validNum = true;
            string inpValue;
            double tempNum;

            do
            {
                if (!validNum)
                {
                    Console.WriteLine("Invalid entry, enter a valid number.");
                }
                inpValue = Console.ReadLine();
                validNum = double.TryParse(inpValue, out tempNum);
            } while (!validNum);

            return tempNum;
        }

        private static string getValidOp()
        {
            Boolean validOp = true;
            string opChar;

            do
            {
                if (!validOp)
                {
                    Console.WriteLine("Invalid entry, enter a valid operator (+, -, /, *).");
                }
                opChar = Console.ReadLine();
                switch (opChar)
                {
                    case "+":
                        validOp = true;
                        break;
                    case "-":
                        validOp = true;
                        break;
                    case "/":
                        validOp = true;
                        break;
                    case "*":
                        validOp = true;
                        break;
                    default:
                        validOp = false;
                        break;
                }
            } while (!validOp);

            return opChar;

        }

        private static double getAnswer(string [] oper, double [] numArray, out Boolean bound)
        {
            Boolean inBounds;
            double tempDouble = numArray[0];

            bound = true;

            for(int x=1; x < numArray.Length; x++)
            {
                tempDouble = evalExpression(oper[x-1], tempDouble, numArray[x], out inBounds);
                if (!inBounds)
                {
                    bound = false;
                    break;
                }
            }
            return tempDouble;
        }

        private static double evalExpression(string op,double fNum, double sNum, out Boolean checkBound)
        {
            switch (op)
            {
                case "+":
                    if (checkAddBound(fNum, sNum))
                    {
                        checkBound = true;
                        return addNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "-":
                    if (checkSubBound(fNum, sNum))
                    {
                        checkBound = true;
                        return subNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "/":
                    if (checkDivBound(fNum, sNum))
                    {
                        checkBound = true;
                        return divNums(fNum, sNum);
                    }
                    checkBound = false;
                    return 0;
                    break;
                case "*":
                    if (checkMultBound(fNum, sNum))
                    {
                        checkBound = true;
                        return multNums(fNum, sNum);
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

        private static double addNums(double fNum, double sNum)
        {
            return fNum + sNum;
        }

        private static double subNums(double fNum, double sNum)
        {
            return fNum - sNum;
        }

        private static double divNums(double fNum, double sNum)
        {
            return fNum / sNum;
        }

        private static double multNums(double fNum, double sNum)
        {
            return fNum * sNum;
        }

        private static Boolean checkAddBound(double fNum, double sNum)
        {
            if (fNum > 0 && sNum > 0 && sNum > (Double.MaxValue - fNum))
            {
                return false;
            }
            else if (fNum < 0 && sNum < 0 && sNum < (Double.MinValue - fNum))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static Boolean checkSubBound(double fNum, double sNum)
        {
            if(fNum > 0 && sNum < 0 && sNum < (fNum - Double.MaxValue))
            {
                return false;
            }
            else if(fNum < 0 && sNum > 0 && sNum > (fNum - Double.MinValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static Boolean checkDivBound(double fNum, double sNum)
        {
            if(sNum == 0)
            {
                return false;
            }
            else if(fNum > 0 && sNum > 0 && sNum < (fNum / Double.MaxValue))
            {
                return false;
            }
            else if(fNum < 0 && sNum < 0 && sNum > (fNum / Double.MaxValue))
            {
                return false;
            }
            else if(getAbsVal(sNum) < (getAbsVal(fNum / Double.MinValue)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static Boolean checkMultBound(double fNum, double sNum)
        {
            if(fNum > 0 && sNum > 0 && sNum > (Double.MaxValue / fNum))
            {
                return false;
            }
            else if(fNum < 0 && sNum < 0 && sNum < (Double.MaxValue / fNum))
            {
                return false;
            }
            else if(fNum > 0 && sNum < 0 && sNum < (Double.MinValue / fNum))
            {
                return false;
            }
            else if(fNum <0 && sNum > 0 && getAbsVal(sNum) > (Double.MinValue / fNum))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static double getAbsVal(double num)
        {
            if (num < 0)
            {
                return -(num);
            }
            return num;
        }

        private static Boolean checkContinue()
        {
            string checkRun;

            checkRun = Console.ReadLine().ToLower();
            while(checkRun != "yes" && checkRun != "no" && checkRun != "y" && checkRun != "n")
            {
                Console.WriteLine("Invalid entry, please enter yes or no.");
                checkRun = Console.ReadLine().ToLower();
            }
            if(checkRun == "no" || checkRun == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                return true;
            }
        }
    }
}
