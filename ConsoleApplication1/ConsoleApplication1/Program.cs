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

            Console.WriteLine();
            bool success;
            int result = 0;
            if (isAValid && isBValid)
            {
                switch (oper)
                {
                    case "+":
                        result = a + b;
                        success = true;
                        break;

                    case "-":
                        result = a - b;
                        success = true;
                        break;

                    default:
                        Console.WriteLine("'{0}' is not a valid operator!", oper);
                        success = false;
                        break;
                }
            }
            else
            {
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
                Console.WriteLine("{0}-side value of '{1}' is not a valid integer!", invalidSide, invalidValue);
                success = false;
            }

            if (success)
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, oper, b, result);
            }
            else
            {
                Console.WriteLine("Cannot calculate result");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
