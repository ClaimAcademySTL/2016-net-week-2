using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Calculator
    {
        private IEvaluatable _expr;
        private double _result = 0;

        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            // Calculate the result
            try
            {
                calc.Run();
                Console.WriteLine(calc.FormatResult());
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
         * Handles any exceptions during parsing. Will throw exception if
         * the expression cannot be evaluated. The result of the evaluation
         * is both returned and stored in the Calculator object.
         */
        public double Run()
        {
            bool isValid;
            // Keep getting user input until we get something valid.
            do
            {
                Input.IParser parser = new Expressions.ExpressionParser();
                Input.InputHandler handler =
                    new Input.InputHandler(parser, "Please enter an expression using binary operators.\nExample expression: '75.3 + -20.7 - 35 * 6e-20'");

                isValid = false;
                try
                {
                    _expr = handler.GetAndParseInput();
                    isValid = true;
                }
                catch (Exception e)
                {
                    // Print out what went wrong.
                    Console.WriteLine(e.Message);
                    // isValid remains false
                }
            } while (!isValid);

            _result = _expr.Evaluate();
            return _result;
        }

        /**
         * Display the result to the user in a helpful way.
         */
        private String FormatResult()
        {
            return String.Format("{0} = {1}", (_expr != null) ? _expr.ToString() : String.Empty, _result);
        }
    }
}
