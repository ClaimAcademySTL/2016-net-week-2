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
            int a, b;
            string operation;
            ProcessAddSubtract(out a, out b, out operation);

            int a = AskforInt();


            int b = AskforInt();


            string operation = AskForOperator2();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, Calculator.AddAnswer(a, b)); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, SubtractAnswer(a, b)); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, MultiplyAnswer(a, b)); }

            Console.ReadLine();




            float a = AskForFloat();


            float b = AskForFloat();

            string operation = AskForOperator2();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, AddAnswerF(a, b)); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, SubtractAnswerF(a, b)); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, MultiplyAnswerF(a, b)); }

            Console.ReadLine();




            float a = AskForFloat();


            float b = AskForFloat();


            string operation = AskForOperator3();

            if (operation == "+")
            { Console.WriteLine("The sum of {0} and {1} is {2}", a, b, Calculator.AddAnswer(a, b)); }

            else if (operation == "-")
            { Console.WriteLine("The difference between {0} and {1} is {2}", a, b, Calculator.SubtractAnswer(a, b)); }

            else if (operation == "*")
            { Console.WriteLine("The product of {0} and {1} is {2}", a, b, Calculator.MultiplyAnswer(a, b)); }

            else if (operation == "/")
            { Console.WriteLine("The quotient of {0} and {1} is {2}", a, b, Calculator.DivideAnswer(a, b)); }
            Console.ReadLine();


            double total_amount_of_mortgage, number_of_months_of_the_loan, yearly_interest_rate;


            total_amount_of_mortgage = AskforMortgageAmount();


            yearly_interest_rate = AskforYearlyRate();


            number_of_months_of_the_loan = AskforNumOfMonths();

            Console.WriteLine("Monthy payment: {0}", (MortgageCalculation(total_amount_of_mortgage, number_of_months_of_the_loan, yearly_interest_rate)));

            Console.ReadLine();




        }

        private static void ProcessAddSubtract(out int a, out int b, out string operation)
        {
            a = AskforInt();
            b = AskforInt();
            operation = AskForOperator();
            if (operation == "+")
                Console.WriteLine("The sum of {0} and {1} is {2}", a, b, AddAnswer(a, b));

            else
                Console.WriteLine("The difference between {0} and {1} is {2}", a, b, SubtractAnswer(a, b));

            Console.ReadLine();
        }

        private static double MortgageCalculation(double total_amount_of_mortgage, double number_of_months_of_the_loan, double yearly_interest_rate)
        {
            double monthly_interest_rate = yearly_interest_rate / 100 / 12;
            double mess = 1 - Math.Pow((1 + monthly_interest_rate), -number_of_months_of_the_loan);
            return monthly_interest_rate / mess * total_amount_of_mortgage;
        }

        public static int AskforInt()
        {
            Console.WriteLine("Give me an integer, please");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string AskForOperator()
        {
            while (true)
            {
                Console.WriteLine("Use the + or - Operator");
                string UserInputOperator = Console.ReadLine();
                if (UserInputOperator == "+" || UserInputOperator == "-")
                {
                    return UserInputOperator;
                }
                else
                {
                    Console.WriteLine("Invalid Response");

                }
            }
        }
        

        public static float AskForFloat()
        {
            Console.WriteLine("Give me a number, please");
            return Convert.ToSingle(Console.ReadLine());
        }
        public static string AskForOperator2()
        {
            while (true)
            {
                Console.WriteLine("Use the +, -, or * Operator");
                string UserInputOperator = Console.ReadLine();
                if (UserInputOperator == "+" || UserInputOperator == "-" || UserInputOperator == "*")
                {
                    return UserInputOperator;
                }
                else
                {
                    Console.WriteLine("Invalid Response");

                }
            }
        }
        public static string AskForOperator3()
        {
            while (true)
            {
                Console.WriteLine("Use the +, -, * or / Operator");
                string UserInputOperator = Console.ReadLine();
                if (UserInputOperator == "+" || UserInputOperator == "-" || UserInputOperator == "*" || UserInputOperator == "/")
                {
                    return UserInputOperator;

                }
                else
                {
                    Console.WriteLine("Invalid Response");


                }
            }
        }
        
        public static int AskforMortgageAmount()
        {
            Console.WriteLine("What is the total amount of the mortgage?");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static double AskforYearlyRate()
        {
            Console.WriteLine("What is the yearly interest rate?");
            return Convert.ToDouble(Console.ReadLine());
        }
        public static int AskforNumOfMonths()
        {
            Console.WriteLine("What's the total number of months of the loan?");
            return Convert.ToInt32(Console.ReadLine());
        }

    }

    class Calculator
    {
        public static float AddAnswer(float left, float right)
        {
            return left + right;
        }
        public static float SubtractAnswer(float left, float right)
        {
            return left - right;
        }
        public static float MultiplyAnswer(float left, float right)
        {
            return left * right;
        }
        public static float DivideAnswer(float left, float right)
        {
            if (right == 0)
            {

            }
            return left / right;
        }

        public static int AddAnswer(int left, int right)
        {
            return left + right;
        }
        public static int SubtractAnswer(int left, int right)
        {
            return left - right;
        }
        public static int MultiplyAnswer(int left, int right)
        {
            return left * right;
        }
    }

}
