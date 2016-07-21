using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Input;

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
                quantityNums = Input.GetPositiveInt();
                Console.WriteLine("\n");

                InputList userInput = new InputList(quantityNums);

                numsToUse = getAllInput(quantityNums, out opers);

                printAnswer(opers, numsToUse);

                Console.WriteLine("Enter yes to run again, or no to stop");
            }while (checkContinue());

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
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
