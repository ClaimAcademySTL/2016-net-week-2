using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a left-hand integer, an operator, and a right-hand
            // integer from the user.
            Console.Write("Integer 1: ");
            int a;
            String aStr = Console.ReadLine();
            bool isAValid = Int32.TryParse(aStr, out a);
            //int a = Int32.Parse(Console.ReadLine());
            Console.Write("Operator (Allowed: +, -): ");
            String oper = Console.ReadLine();
            Console.Write("Integer 2: ");
            int b;
            String bStr = Console.ReadLine();
            bool isBValid = Int32.TryParse(bStr, out b);
            //int b = Int32.Parse(Console.ReadLine());

            // Check whether the user entered valid integers.
            Console.WriteLine();
            bool success;
            int result = 0;
            if (isAValid && isBValid)
            {
                // If the user entered valid integers, look at the operator.
                switch (oper)
                {
                    // User wants to add
                    case "+":
                        result = a + b;
                        success = true;
                        break;

                    // User wants to subtract
                    case "-":
                        result = a - b;
                        success = true;
                        break;

                    // User entered some strange thing we don't understand.
                    // Give an informative error message.
                    default:
                        Console.WriteLine("'{0}' is not a valid operator!", oper);
                        success = false;
                        break;
                }
            }
            else
            {
                // One of the integers was invalid. Which one?
                String invalidValue;
                String invalidSide;
                if (!isAValid)
                {
                    invalidValue = aStr;
                    invalidSide = "Left";

                }
                else
                {
                    invalidValue = bStr;
                    invalidSide = "Right";
                }

                // Give an informative error message.
                Console.WriteLine("{0}-side value of '{1}' is not a valid integer!", invalidSide, invalidValue);
                success = false;
            }

            // If everything was good, show the result.
            if (success)
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, oper, b, result);
            }
            else
            {
                // Something went wrong. Let the user know.
                Console.WriteLine("Cannot calculate result");
            }

            // Keep the program open so the user can read the result.
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
