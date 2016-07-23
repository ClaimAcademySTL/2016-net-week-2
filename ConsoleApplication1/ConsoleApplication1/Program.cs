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
            bool isValid;
            Expressions.Expression expr;

            // Keep getting user input until we get something valid.
            do
            {
                String errorMsg;
                Input.IParser<Expressions.Expression> parser = new Expressions.ExpressionParser();
                Input.InputHandler<Expressions.Expression> handler = new Input.InputHandler<Expressions.Expression>(parser);
                isValid = handler.GetAndParseInput(out expr, out errorMsg);
                if (!isValid)
                {
                    Console.WriteLine(errorMsg);
                }
            } while (!isValid);

            // Calculate the result
            double result;
            try
            {
                result = expr.Evaluate();
                ShowResult(expr, result);
            }
            catch (Exception e)
            {
                // Something went wrong. Let the user know.
                Console.WriteLine("Cannot calculate result.\n{0}", e.Message);
            }
            

            // Keep the program open so the user can read the result.
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        /**
         * Display the result to the user in a helpful way.
         */
        private static void ShowResult(Expressions.Expression expr, double result)
        {
            Console.WriteLine("{0} = {1}", expr, result);
        }
    }
}
