using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Addition.DoIt(5, 2));

            Console.WriteLine(Addition.DoIt(5, 2, 3));

            Console.WriteLine(Addition.DoIt(1, 2, 3, 4, 5, 6, 7, 8, 9));

            Console.ReadKey();
        }
    }

    class Addition
    {
        public static int DoIt(int number1, int number2)
        {
            return number1 + number2;
        }

        public static int DoIt(int number1, int number2, int number3)
        {
            return DoIt(number1, number2) + number3;
        }

        public static int DoIt(params int[] numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
