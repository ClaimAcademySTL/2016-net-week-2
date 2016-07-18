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
            bool run, f, s, checkOp;
            string firstInt, secondInt, opChar, checkRun;
            int fInt, sInt;

            run = true;

            while (run)
            {
                Console.WriteLine("Please enter an integer value");
                firstInt = Console.ReadLine();
                f = int.TryParse(firstInt, out fInt);
                while (!f)
                {
                    Console.WriteLine("Invalid entry, please enter valid integer.");
                    firstInt = Console.ReadLine();
                    f = int.TryParse(firstInt, out fInt);
                }
                Console.WriteLine("Please enter another integer value");
                secondInt = Console.ReadLine();
                s = int.TryParse(secondInt, out sInt);
                while (!s)
                {
                    Console.WriteLine("Invalid entry, please enter valid integer.");
                    secondInt = Console.ReadLine();
                    s = int.TryParse(secondInt, out sInt);
                }

                Console.WriteLine("Please enter the operation symbol you would like to use on the two integers(+, -, /, or *).");
                opChar = Console.ReadLine();
                checkOp = false;
                while (!checkOp)
                {
                    switch (opChar)
                    {
                        case "+":
                            Console.WriteLine("{0} + {1} = {2}", fInt, sInt, fInt + sInt);
                            checkOp = true;
                            break;
                        case "-":
                            Console.WriteLine("{0} - {1} = {2}", fInt, sInt, fInt - sInt);
                            checkOp = true;
                            break;
                        case "/":
                            Console.WriteLine("{0} / {1} = {2}", fInt, sInt, fInt / sInt);
                            checkOp = true;
                            break;
                        case "*":
                            Console.WriteLine("{0} * {1} = {2}", fInt, sInt, fInt * sInt);
                            checkOp = true;
                            break;
                        default:
                            Console.WriteLine("Invalid entry, please enter valid operator.");
                            break;
                    }
                }

                Console.WriteLine("Would you like to run again? (yes or no)");
                checkRun = Console.ReadLine().ToLower();
                while(checkRun != "yes" && checkRun != "no")
                {
                    Console.WriteLine("Invalid entry, please enter yes or no.");
                    checkRun = Console.ReadLine().ToLower();
                }
                if(checkRun == "no")
                {
                    run = false;
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
