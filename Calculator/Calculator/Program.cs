using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run, f, s, checkOp, bothNeg,bothPos,firstNeg,firstPos;
            string firstInp, secondInp, opChar, checkRun;
            double fNum, sNum, upperBound, lowerBound;

            do
            {
                //Collecting user input of two numbers and checking for input errors
                Console.WriteLine("Please enter a number");
                firstInp = Console.ReadLine();
                f = double.TryParse(firstInp, out fNum);
                while (!f)
                {
                    Console.WriteLine("Invalid entry, please enter a valid number.");
                    firstInp = Console.ReadLine();
                    f = double.TryParse(firstInp, out fNum);
                }
                Console.WriteLine("Please enter another number.");
                secondInp = Console.ReadLine();
                s = double.TryParse(secondInp, out sNum);
                while (!s)
                {
                    Console.WriteLine("Invalid entry, please enter a valid number.");
                    secondInp = Console.ReadLine();
                    s = double.TryParse(secondInp, out sNum);
                }

                //checking which number is positive and which is negative, assign values to bools
                if (fNum > 0 && sNum > 0)
                {
                    bothPos = true;
                    bothNeg = false;
                    firstPos = false;
                    firstNeg = false;
                }
                else if (fNum < 0 && sNum < 0)
                {
                    bothPos = false;
                    bothNeg = true;
                    firstPos = false;
                    firstNeg = false;
                }
                else if(fNum > 0 && sNum < 0)
                {
                    bothPos = false;
                    bothNeg = false;
                    firstPos = true;
                    firstNeg = false;
                }
                else
                {
                    bothPos = false;
                    bothNeg = false;
                    firstPos = false;
                    firstNeg = true;
                }

                //collecting user input for operator
                Console.WriteLine("Please enter the operation symbol you would like to use on the two numbers(+, -, /, or *).");
                opChar = Console.ReadLine();

                //checking for input error, boundary error, or printing out expression based on provided operator
                do
                {
                    switch (opChar)
                    {
                        case "+":
                            upperBound = Double.MaxValue - fNum;
                            lowerBound = Double.MinValue - fNum;
                            if (bothPos && sNum > upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if (bothNeg && sNum < lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else
                            {
                                Console.WriteLine("{0} + {1} = {2}", fNum, sNum, fNum + sNum);
                            }
                            checkOp = true;
                            break;
                        case "-":
                            upperBound = fNum - Double.MaxValue;
                            lowerBound = fNum - Double.MinValue;
                            if(firstPos && sNum < upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if(firstNeg && sNum>lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else
                            {
                                Console.WriteLine("{0} - {1} = {2}", fNum, sNum, fNum - sNum);
                            }
                            checkOp = true;
                            break;
                        case "/":
                            upperBound = fNum / Double.MaxValue;
                            lowerBound = fNum / Double.MinValue;
                            if (sNum == 0)
                            {
                                Console.WriteLine("Well...you can't divide by 0.");
                            }
                            else if (bothPos && sNum < upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if (bothNeg && sNum > upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if (firstPos && -(sNum) > lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if(firstNeg && -(sNum) < lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else
                            {
                                Console.WriteLine("{0} / {1} = {2}", fNum, sNum, fNum / sNum);
                            }
                            checkOp = true;
                            break;
                        case "*":
                            upperBound = Double.MaxValue / fNum;
                            lowerBound = Double.MinValue / fNum;
                            if(bothPos && sNum > upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if(bothNeg && sNum < upperBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if(firstPos && sNum < lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else if(firstNeg && -(sNum) < lowerBound)
                            {
                                Console.WriteLine("Oops, you went out of bounds.");
                            }
                            else
                            {
                                Console.WriteLine("{0} * {1} = {2}", fNum, sNum, fNum * sNum);
                            }
                            checkOp = true;
                            break;
                        default:
                            Console.WriteLine("Invalid entry, please enter valid operator.");
                            opChar = Console.ReadLine();
                            checkOp = false;
                            break;
                    }
                } while (!checkOp);

                //Collecting user input to decide whether to exit or evaluate another expression, while checking for input error
                Console.WriteLine("Would you like to run again? (yes or no)");
                checkRun = Console.ReadLine().ToLower();
                while (checkRun != "yes" && checkRun != "no")
                {
                    Console.WriteLine("Invalid entry, please enter yes or no.");
                    checkRun = Console.ReadLine().ToLower();
                }
                if (checkRun == "no")
                {
                    run = false;
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                else
                {
                    run = true;
                }
                Console.WriteLine();
                Console.WriteLine();
            } while (run);
        }
    }
}
