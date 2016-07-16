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
            Console.WriteLine("Please enter an integer value");
            string firstInt = Console.ReadLine();
            Console.WriteLine("Please enter another integer value");
            string secondInt = Console.ReadLine();
            int fInt = 0;
            int sInt=0;
            bool f = int.TryParse(firstInt, out fInt);
            bool s = int.TryParse(secondInt, out sInt);
            while (!f || !s){

                if (!f)
                {
                    Console.WriteLine("Invalid entry for first integer, please enter valid integer.");
                    firstInt = Console.ReadLine();
                    f = int.TryParse(firstInt, out fInt);
                }
                if (!s)
                {
                    Console.WriteLine("Invalid entry for second integer, please enter valid integer.");
                    secondInt = Console.ReadLine();
                    s = int.TryParse(secondInt, out sInt);
                }
            }

            Console.WriteLine("Please enter the operation symbol you would like to use on the two integers(+ or -).");
            string opChar = Console.ReadLine();
            while(opChar != "+")
            {
                if(opChar == "-")
                {
                    break;
                }
                Console.WriteLine("Invalid entry, please enter either + or -");
                opChar = Console.ReadLine();
            }

            if(opChar == "+")
            {
                Console.WriteLine("{0} + {1} = {2}", fInt, sInt, fInt + sInt);
            }
            else if(opChar == "-")
            {
                Console.WriteLine("{0} - {1} = {2}", fInt, sInt, fInt - sInt);
            }
            Console.ReadKey();
        }
    }
}
