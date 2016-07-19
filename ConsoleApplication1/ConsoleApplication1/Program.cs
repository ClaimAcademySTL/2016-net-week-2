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
            String[] allowedOperators = { "+", "-", "*", "/", "%" };
            bool isValid;
            int a, b;
            String oper;

            // Keep getting user input until we get something valid.
            do
            {
                string inp = GetUserInput(allowedOperators);
                String errorMsg;
                isValid = ParseInput(inp, allowedOperators, out a, out oper, out b, out errorMsg);
                if (!isValid)
                {
                    Console.WriteLine(errorMsg);
                }
            } while (!isValid);

            int result = 0;
            String resultError;
            switch (oper)
            {
                // User wants to add
                case "+":
                    {
                        result = Add(a, b, out resultError);
                        break;
                    }

                // User wants to subtract
                case "-":
                    {
                        result = Subtract(a, b, out resultError);
                        break;
                    }

                case "*":
                    {
                        result = Multiply(a, b, out resultError);
                        break;
                    }

                case "/":
                    {
                        result = Divide(a, b, out resultError);
                        break;
                    }

                case "%":
                    {
                        result = GetRemainder(a, b, out resultError);
                        break;
                    }

                
                default:
                    {
                        // We should never get here unless allowedOperators is wrong.
                        resultError = String.Format("'{0}' is not a valid operator!", oper);
                        break;
                    }
            }
            
            

            // If everything was good, show the result.
            if (resultError.Equals(""))
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, oper, b, result);
            }
            else
            {
                // Something went wrong. Let the user know.
                Console.WriteLine("Cannot calculate result.\n" + resultError);
            }

            // Keep the program open so the user can read the result.
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        public static int Add(int a, int b, out String errorMsg)
        {
            errorMsg = "";

            if (IsAdditionValid(a, b))
            {
                return a + b;
            }
            else
            {
                errorMsg ="Result would overflow!";
                return 0;
            }
        }

        public static int Subtract(int a, int b, out String errorMsg)
        {
            errorMsg = "";
            if (IsSubtractionValid(a, b))
            {
                return a - b;
            }
            else
            {
                errorMsg = "Result would overflow!";
                return 0;
            }
        }

        public static int Multiply(int a, int b, out String errorMsg)
        {
            errorMsg = "";
            if (IsMultiplicationValid(a, b))
            {
                return a * b;
            }
            else
            {
                errorMsg = "Result would overflow!";
                return 0;
            }

        }

        public static int Divide(int a, int b, out String errorMsg)
        {
            errorMsg = "";
            if (IsDivisionValid(a, b))
            {
                return a / b;
            }
            else
            {
                errorMsg = "Attempted to divide by zero!";
                return 0;
            }

        }

        public static int GetRemainder(int a, int b, out String errorMsg)
        {
            errorMsg = "";
            if (IsModulusValid(a, b))
            {
                return a % b;
            }
            else
            {
                errorMsg = "Attempted to divide by zero!";
                return 0;
            }

        }

        /**
         * Returns true if parsed successfully, false otherwise.
         * errorMsg parameter will be an empty string upon success, 
         * or non-empty string upon failure).
         */
        private static bool ParseInput(string inp, String[] allowedOperators, out int left, out String oper, out int right, out String errorMsg)
        {
            left = 0;
            oper = "";
            right = 0;

            bool result = true;

            String[] tokens = inp.Split(' ');
            errorMsg = GetBinaryExprError(inp, tokens);
            if (!errorMsg.Equals(""))
            {
                result = false;
            }
            else
            {

                if (!int.TryParse(tokens[0], out left))
                {
                    errorMsg += String.Format("Left-side value '{0}' is not a valid integer!\n", tokens[0]);
                    result = false;
                }
                if (!int.TryParse(tokens[2], out right))
                {
                    errorMsg += String.Format("Right-side value '{0}' is not a valid integer!\n", tokens[2]);
                    result = false;
                }

                oper = tokens[1];
                if (!IsOperatorValid(oper, allowedOperators))
                {
                    errorMsg += String.Format("'{0} is not a valid operator!\n", oper);
                    result = false;
                }
            }

            return result;
        }

        private static bool IsOperatorValid(string oper, string[] allowedOperators)
        {
            foreach (String testOper in allowedOperators)
            {
                if (oper.Equals(testOper))
                {
                    return true;
                }
            }
            return false;
        }

        public static String GetBinaryExprError(String inp, String[] tokens)
        {
            if (tokens.Length == 3)
            {
                // Expression is binary, no error
                return "";
            }

            // Otherwise, not a binary expression. Either too few or
            // too many tokens.
            String tooManyOrNotEnough;
            String extraMessage = "";
            if (tokens.Length < 3)
            {
                // Too few tokens. Add another helpful message
                tooManyOrNotEnough = "Not enough";
                extraMessage = "\nAre the tokens separated by spaces?";

            }
            else
            {
                // Too many tokens
                tooManyOrNotEnough = "Too many";
            }

            return String.Format("{0} space-separated tokens in '{1}'. Expected 3, found {2}.{3}",
                tooManyOrNotEnough, inp, tokens.Length, extraMessage);

        }

        private static string GetUserInput(String[] operators)
        {
            String prompt = "Please enter a simple expression with two integers and a binary operator.\nAllowed operators are(";
            for (int i = 0; i < operators.Length; i++)
            {
                prompt += String.Format("'{0}'", operators[i]);
                if (i < operators.Length - 1)
                {
                    prompt += ", ";
                }
            }
            prompt += ").\nExample expression: '75 + -20'\n  > ";
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static bool IsDivisionValid(int a, int b)
        {
            return b != 0;
        }

        public static bool IsModulusValid(int a, int b)
        {
            return b != 0;
        }

        private static bool IsMultiplicationValid(int a, int b)
        {
            bool willOverflow = false;
            // Can't overflow if either operand is 0.
            // Can overflow past MaxValue if both signs
            // are the same, or past MinValue if both
            // operands have opposite sign.

            // Not sure if this works when a or b is equal to
            // int.MinValue.
            if (a != 0 && b != 0)
            {
                int signA = (a > 0) ? 1 : -1;
                int absA = a * signA;
                int signB = (b > 0) ? 1 : -1;
                int absB = b * signB;
                if (signA == signB)
                {
                    int roomForOverflow = int.MaxValue / absA;
                    willOverflow = (absB > roomForOverflow);
                }
                else
                {
                    int roomForOverflow = (int.MinValue / absA);
                    willOverflow = (absB > -roomForOverflow);
                }
            }

            return !willOverflow;
        }

        private static bool IsSubtractionValid(int a, int b)
        {
            // We can only overflow if both a and b have opposite sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (a > 0 && b < 0)
            {
                int roomForOverflow = int.MaxValue - a; // non-negative
                willOverflow = (b < -roomForOverflow);
            }
            else if (a < 0 && b > 0)
            {
                int roomForOverflow = int.MinValue - a; // non-positive
                willOverflow = (b > -roomForOverflow);
            }

            return !willOverflow;
        }

        private static bool IsAdditionValid(int a, int b)
        {
            // We can only overflow if both a and b have the same sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (a > 0 && b > 0)
            {
                int roomForOverflow = int.MaxValue - a; // non-negative
                willOverflow = (b > roomForOverflow);
            }
            else if (a < 0 && b < 0)
            {
                int roomForOverflow = int.MinValue - a; // non-positive
                willOverflow = (b < roomForOverflow);
            }

            return !willOverflow;
        }
    }
}
