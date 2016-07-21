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
            // Determine what operators can be used and their order
            // of operations.
            String[] allowedOperators = { "+", "-", "*", "/", "%" };
            String[][] orderOfOperations = new String[][]
            {
                new String[] {"*", "/", "%" },
                new String[] {"+", "-"}
            };

            bool isValid;
            String[] inputTokens;
            double[] inputOperands;

            // Keep getting user input until we get something valid.
            do
            {
                String errorMsg;
                String userInput = GetUserInput(allowedOperators);
                isValid = ParseInput(userInput, allowedOperators, out inputTokens, out inputOperands, out errorMsg);
                if (!isValid)
                {
                    Console.WriteLine(errorMsg);
                }
            } while (!isValid);

            // Calculate the result
            String resultError;
            double result;
            bool success = DoOperations(inputTokens, inputOperands, orderOfOperations, out result, out resultError);

            // If everything was good, show the result.
            if (success)
            {
                ShowResult(inputTokens, inputOperands, result);
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

        /**
         * Display the result to the user in a helpful way.
         */
        private static void ShowResult(string[] inputTokens, double[] inputOperands, double result)
        {
            // Reconstruct the input expression
            String expr = "";
            for (int i = 0; i < inputTokens.Length; i++)
            {
                if (i % 2 == 0)
                {
                    // Even-numbered tokens are numeric operands.
                    expr += inputOperands[i].ToString();
                }
                else
                {
                    // Odd-numbered tokens are operators, stored as strings.
                    expr += inputTokens[i];
                }
                // Separate each token with a space. This will also add a space after
                // the last token.
                expr += " ";
            }

            // Write out to the screen
            Console.WriteLine("{0}= {1}", expr, result);
        }

        /**
         * Do one or more operations, using the correct order of operations. 
         * Convenience method that doesn't need a starting and ending point 
         * (which is needed by RecurseOperations).
         */
        private static bool DoOperations(String[] inputTokens, double[] inputOperands, String[][] operatorOrder, out double result, out String errorMsg)
        {
            return RecurseOperations(inputTokens, inputOperands, operatorOrder, 0, inputTokens.Length, out result, out errorMsg);
        }

        /**
         * Recursively do one or more operations, using the correct order of operations.
         * Takes a starting and stopping index to determine what portion of the tokens/operands
         * to process. startIndex is included, stopIndex is excluded.
         */
        private static bool RecurseOperations(String[] inputTokens, double[] inputOperands, String[][] operatorOrder, int startIndex, int stopIndex, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            if (stopIndex - startIndex == 1)
            {
                // Base case, a single value
                result = inputOperands[startIndex];
                return true;
            }

            // Find the rightmost, lowest precedence operator. This allows
            // all the higher precedence operators to be evaluated (in leftResult
            // and rightResult) before we call DoOperation on this one.
            int operIndex = FindLastOperatorWithPrecedence(inputTokens, operatorOrder, startIndex, stopIndex);

            // Get the results for each side of the operator
            double leftResult;
            double rightResult = 0;
            bool success = (RecurseOperations(inputTokens, inputOperands, operatorOrder, startIndex, operIndex, out leftResult, out errorMsg) &&
                RecurseOperations(inputTokens, inputOperands, operatorOrder, operIndex + 1, stopIndex, out rightResult, out errorMsg));

            if (success)
            {
                // Combine the results
                success = DoOperation(leftResult, rightResult, inputTokens[operIndex], out result, out errorMsg);
            }

            return success;
        }

        
        /**
         * Determine the precedence level of an operator, based on a given order of operations.
         * A lower level corresponds to a higher precedence, with the highest possible
         * precedence corresponding to level 0.
         */
        private static int GetOperatorPrecedenceLevel(String oper, String[][] operatorOrder)
        {
            int level = -1;
            // If we can assume that all the odd-numbered tokens are valid operators
            // and that all valid operators are included in operatorOrder, then we
            // don't need to test the last level of precedence. If we haven't found 
            // the correct level of precedence  before we reach the last one, then 
            // we know it must be the last level.
            for (int currentLevel = 0; currentLevel < operatorOrder.Length - 1; currentLevel++)
            {
                // operatorOrder[currentLevel] is the array of "allowed" operators
                // in the current precedence level. If oper is valid against this
                // array, then this is the correct precedence level.
                if (IsOperatorValid(oper, operatorOrder[currentLevel]))
                {
                    level = currentLevel;
                    break;
                }
            }
            if (level == -1)
            {
                // We didn't find the level, so it must be the last level.
                level = operatorOrder.Length - 1;
            }

            return level;
        }

        /**
         * Find the array index of operator with the lowest precedence. If there are 
         * multiple operators tying for lowest precedence, returns index of the 
         * rightmost of the tied operators.
         */
        private static int FindLastOperatorWithPrecedence(String[] tokens, String[][] operatorOrder, int startIndex, int stopIndex)
        {
            int worstPrecedence = -1;
            int worstPossiblePrecedence = operatorOrder.Length - 1;
            int worstIndex = -1;
            
            for (int i = stopIndex - 2; i > startIndex; i -= 2)
            {
                int precedence = GetOperatorPrecedenceLevel(tokens[i], operatorOrder);
                if (precedence > worstPrecedence)
                {
                    worstPrecedence = precedence;
                    worstIndex = i;
                }
                if (worstPrecedence == worstPossiblePrecedence)
                {
                    // We have the lowest possible level. No point in continuing
                    // to search.
                    break;
                }
            }

            return worstIndex;
        }

        /**
         * Calculate the result of a single arithmetic operation
         */
        private static bool DoOperation(double left, double right, String operatorSymbol, out double result, out String errorMsg)
        {
            result = 0;

            Operators.BinaryOperator oper = Operators.BinaryOperatorFactory.Create(operatorSymbol, out errorMsg);
            if (oper == null)
            {
                // Failed to get the operator
                return false;
            }
            
            // Operator successful, do the operation
            return oper.PerformOperation(left, right, out result, out errorMsg);

            //switch (operatorSymbol)
            //{
            //    // User wants to add
            //    case "+":
            //        return Add(left, right, out result, out errorMsg);

            //    // User wants to subtract
            //    case "-":
            //        return Subtract(left, right, out result, out errorMsg);

            //    // User wants to multiply
            //    case "*":
            //        return Multiply(left, right, out result, out errorMsg);

            //    // User wants to divide
            //    case "/":
            //        return Divide(left, right, out result, out errorMsg);

            //    // User wants to use the modulus operator
            //    case "%":
            //        return GetRemainder(left, right, out result, out errorMsg);

            //    default:
            //        // We should never get here unless allowedOperators is wrong.
            //        errorMsg = String.Format("'{0}' is not a valid operator!", operatorSymbol);
            //        result = 0;
            //        return false;

            //}
        }

        /**
         * Add two doubles if the result would not be greater than double.MaxValue
         * or less than double.MinValue. Returns true if successful, false otherwise.
         * Precision could be lost without returning false (for example, when adding 
         * two numbers which greatly differ in magnitude).
         */
        public static bool Add(double a, double b, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            bool success;

            if (IsAdditionValid(a, b))
            {
                result = a + b;
                success = true;
            }
            else
            {
                errorMsg ="Result would overflow!";
                success = false;
            }

            return success;
        }

        /**
         * Subtract b from a if the result would not be greater than double.MaxValue
         * or less than double.MinValue. Returns true if successful, false otherwise.
         * Precision could be lost without returning false (for example, when 
         * subtracting numbers which greatly differ in magnitude).
         */
        public static bool Subtract(double a, double b, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            bool success;
            if (IsSubtractionValid(a, b))
            {
                result = a - b;
                success = true;
            }
            else
            {
                errorMsg = "Result would overflow!";
                success = false;
            }

            return success;
        }

        /**
         * Multiply two doubles if the result would not be greater than double.MaxValue
         * or less than double.MinValue. Returns true if successful, false otherwise.
         * Precision could be lost without returning false (for example, when adding 
         * two numbers that each have a very small magnitude, the result could be 0).
         */
        public static bool Multiply(double a, double b, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            bool success;
            if (IsMultiplicationValid(a, b))
            {
                result = a * b;
                success = true;
            }
            else
            {
                errorMsg = "Result would overflow!";
                success = false;
            }

            return success;
        }

        /**
         * Divide a by b if the result would not be greater than double.MaxValue
         * or less than double.MinValue. Returns true if successful, false otherwise.
         * Precision could be lost without returning false (for example, when dividing 
         * a very small magnitude number by a large magnitude number, the result could
         * be 0).
         */
        public static bool Divide(double a, double b, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            bool success;
            if (IsDivisionValid(a, b))
            {
                result = a / b;
                success = true;
            }
            else
            {
                errorMsg = "Result would overflow!";
                success = false;
            }

            return success;
        }

        /**
         * Compute a % b as long as b is not 0. Returns true if successful, false 
         * otherwise. 
         */
        public static bool GetRemainder(double a, double b, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            bool success;
            if (IsModulusValid(a, b))
            {
                result = a % b;
                success = true;
            }
            else
            {
                errorMsg = "Attempted to divide by zero!";
                success = false;
            }

            return success;
        }

        /**
         * Determines whether a given string is contained in an array of possible
         * operators.
         */
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

        /**
         * Parse input into an array of tokens and an array of numeric operands.
         * Each odd-numbered element of tokens will hold an operator in the form
         * of a String (even-numbered elements should be ignored, as they contain
         * the String form of the operands, as the user typed them). Each 
         * even-numbered element of operands is a numeric operand (odd-numbered 
         * elements contain 0.0 and should be ignored). Returns true if parsing
         * was successful, false otherwise.
         */
        private static bool ParseInput(String inputString, String[] operators, out String[] tokens, out double[] operands, out String errorMsg)
        {
            errorMsg = null;
            operands = null;
            tokens = inputString.Split(' ');

            // Must have an odd number of tokens, with at least 3, or else
            // we don't have a series of binary operators.
            bool isLengthValid;
            if (tokens.Length > 2 && tokens.Length % 2 == 1)
            {
                isLengthValid = true;
            }
            else
            {
                isLengthValid = false;
                errorMsg = "Invalid number of tokens. Expression is not a series of binary operators with operands.";
            }
            bool areOperatorsValid = false;
            bool areOperandsValid = false;
            if (isLengthValid)
            {
                areOperatorsValid = CheckOperators(operators, tokens, out errorMsg);
            }
            if (areOperatorsValid)
            {
                areOperandsValid = ConvertOperands(tokens, out operands, out errorMsg);
            }
            return areOperandsValid;
        }

        /**
         * Prompt the user for an expression, and return the string that the 
         * user enters.
         */
        private static string GetUserInput(string[] operators)
        {
            String prompt = "Please enter an expression using binary operators.\nAllowed operators are(";
            for (int i = 0; i < operators.Length; i++)
            {
                prompt += String.Format("'{0}'", operators[i]);
                if (i < operators.Length - 1)
                {
                    prompt += ", ";
                }
            }
            prompt += ").\nExample expression: '75.3 + -20.7 - 35 * 6e-20'\n  > ";
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /**
         * Check each operator in tokens to make sure it is in the array
         * of valid operators.
         */
        private static bool CheckOperators(String[] allowedOperators, String[] tokens, out String errorMsg)
        {
            errorMsg = null;
            bool result = true;
            // Each odd-numbered element must be an operator.
            for (int tokenIndex = 1; tokenIndex < tokens.Length; tokenIndex += 2)
            {
                if (!IsOperatorValid(tokens[tokenIndex], allowedOperators))
                {
                    // Not a valid operator. No need to continue checking.
                    errorMsg = String.Format("'{0}' is not a valid operator!", tokens[tokenIndex]);
                    result = false;
                    break;
                }
            }
            return result;
        }

        /**
         * Convert all the numeric operands in the String array tokens from
         * Strings to doubles. Odd-numbered elements of the out array operands
         * are 0.0 and should be ignored. Each even-numbered index in operands
         * holds the value corresponding to the same index in tokens. Returns 
         * true if successful, false otherwise.
         */
        private static bool ConvertOperands(String[] tokens, out double[] operands, out String errorMsg)
        {
            errorMsg = null;
            bool result = false;

            // This wastes space, but makes handling easier. The operands remain keep the same
            // indices in the output array that they had in the tokens array.
            operands = new double[tokens.Length];

            // Each even-numbered element must be an operand.
            for (int tokenIndex = 0; tokenIndex < tokens.Length; tokenIndex += 2)
            {
                result = double.TryParse(tokens[tokenIndex], out operands[tokenIndex]);
                if (!result)
                {
                    // Not a valid operand. No need to continue checking.
                    errorMsg = String.Format("'{0}' is not a valid number!", tokens[tokenIndex]);
                    break;
                }

            }

            return result;
        }

        /**
         * Determine whether we can successfully divide a by b.
         */
        public static bool IsDivisionValid(double a, double b)
        {
            bool willOverflow = false;
            // Can't overflow if first operand is 0.
            // Can only overflow if absolute value of first
            // operand is greater than 1 and absolute value
            // of second operand is less than 1.
            // Can overflow past MaxValue if both signs
            // are the same, or past MinValue if both
            // operands have opposite sign.
            if ((a < -1 || a > 1) && (b > -1 && b < 1))
            {
                double absA, absB;
                int signA = GetSign(a, out absA);
                int signB = GetSign(b, out absB);
                if (signA == signB)
                {
                    willOverflow = (absA > absB * double.MaxValue);
                }
                else
                {
                    willOverflow = (absA > -absB * double.MinValue);
                }
            }
            return !willOverflow;
        }

        /**
         * Determine whether we can successfully compute a % b.
         */
        public static bool IsModulusValid(double a, double b)
        {
            return b != 0;
        }

        /**
         * Determine whether we can successfully multiply two values.
         */
        private static bool IsMultiplicationValid(double a, double b)
        {
            bool willOverflow = false;
            // Can't overflow if absolute value of either 
            // operand is less than 1.
            // Can overflow past MaxValue if both signs
            // are the same, or past MinValue if both
            // operands have opposite sign.
            if ((a < -1 || a > 1) && (b < -1 || b > 1))
            {
                double absA, absB;
                int signA = GetSign(a, out absA);
                int signB = GetSign(b, out absB);
                if (signA == signB)
                {
                    double roomForOverflow = double.MaxValue / absA;
                    willOverflow = (absB > roomForOverflow);
                }
                else
                {
                    double roomForOverflow = (double.MinValue / absA);
                    willOverflow = (absB > -roomForOverflow);
                }
            }

            return !willOverflow;
        }

        /**
         * Determine whether we can successfully subtract b from a.
         */
        private static bool IsSubtractionValid(double a, double b)
        {
            // We can only overflow if both a and b have opposite sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (a > 0 && b < 0)
            {
                double roomForOverflow = double.MaxValue - a; // non-negative
                willOverflow = (b < -roomForOverflow);
            }
            else if (a < 0 && b > 0)
            {
                double roomForOverflow = double.MinValue - a; // non-positive
                willOverflow = (b > -roomForOverflow);
            }

            return !willOverflow;
        }

        /**
         * Determine whether we can successfully add two values.
         */
        private static bool IsAdditionValid(double a, double b)
        {
            // We can only overflow if both a and b have the same sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (a > 0 && b > 0)
            {
                double roomForOverflow = double.MaxValue - a; // non-negative
                willOverflow = (b > roomForOverflow);
            }
            else if (a < 0 && b < 0)
            {
                double roomForOverflow = double.MinValue - a; // non-positive
                willOverflow = (b < roomForOverflow);
            }

            return !willOverflow;
        }

        /**
         * Get the sign and absolute value of val. Return 1 for positive,
         * -1 for negative, or 0 for 0.
         */
        private static int GetSign(double val, out double absoluteValue)
        {
            int sign;
            if (val > 0)
            {
                sign = 1;
            }
            else if (val < 0)
            {
                sign = -1;
            }
            else
            {
                sign = 0;
            }
            absoluteValue = val * sign;
            return sign;
        }
    }
}
