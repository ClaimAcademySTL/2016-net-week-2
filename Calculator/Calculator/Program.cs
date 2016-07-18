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
            /* 
             Console.WriteLine("Enter first integer");
             int a = Convert.ToInt32(Console.ReadLine());

             Console.WriteLine("Enter second integer");
             int b = Convert.ToInt32(Console.ReadLine());

             Console.WriteLine("Enter operation + or -");
             string operation = Console.ReadLine();

             if (operation == "+")
             Console.WriteLine("The sum of {0} and {1} is {2}",a,b, a + b);

             else 
             Console.WriteLine("The difference between {0} and {1} is {2}",a,b,a - b);
             Console.ReadLine();
             */

            /*
            Console.WriteLine("Enter first integer");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second integer");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter operation +, -, *");
            string operation = Console.ReadLine();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, a + b); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, a - b); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, a * b); }

            Console.ReadLine();
            */

            /*
            Console.WriteLine("Enter first number");
            float a = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter second number");
            float b = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter operation +, -, *");
            string operation = Console.ReadLine();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, a + b); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, a - b); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, a * b); }

            Console.ReadLine();
            */

            Console.WriteLine("Enter first number");
            float a = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter second number");
            float b = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter operation +, -, *, /");
            string operation = Console.ReadLine();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, a + b); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, a - b); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, a * b); }

            else if (operation == "/")
            { Console.WriteLine("The quotient of {0} and {1} is {2}", a, b, a / b); }

            Console.ReadLine();

        }

    }
}
