using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Input
    {
        private static Boolean isValid = true;
        private static string uInput;
        private static int outInt;
        private static double outDouble;

        public static int GetPositiveInt()
        {
            uInput = Console.ReadLine();
            do
            {
                if (!isValid)
                {
                    Console.WriteLine("Invalid entry, enter a valid positive integer.");
                    uInput = Console.ReadLine();
                }
                isValid = int.TryParse(uInput, out outInt);
                if (isValid && outInt <= 0)
                {
                    isValid = false;
                }
            } while (!isValid);

            return outInt;
        }

        public static string GetOperator()
        {
            uInput = Console.ReadLine();
            do
            {
                if (!isValid)
                {
                    Console.WriteLine("Invalid entry, enter a valid operator (+, -, /, *).");
                    uInput = Console.ReadLine();
                }
                switch (uInput)
                {
                    case "+":
                        isValid = true;
                        break;
                    case "-":
                        isValid = true;
                        break;
                    case "/":
                        isValid = true;
                        break;
                    case "*":
                        isValid = true;
                        break;
                    default:
                        isValid = false;
                        break;
                }
            } while (!isValid);

            return uInput;
        }

        public static double GetDouble()
        {
            uInput = Console.ReadLine();
            do
            {
                if (!isValid)
                {
                    Console.WriteLine("Invalid entry, enter a valid number.");
                    uInput = Console.ReadLine();
                }
                isValid = double.TryParse(uInput, out outDouble);
            } while (!isValid);

            return outDouble;
        }
    }
}
