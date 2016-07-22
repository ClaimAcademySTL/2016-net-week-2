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
            //String[] inputTokens;
            double[] inputOperands;
            Operators.BinaryOperator[] operators;

            // Keep getting user input until we get something valid.
            do
            {
                String errorMsg;
                isValid = Input.InputHandler.GetAndParseInput(out operators, out inputOperands, out errorMsg);
                if (!isValid)
                {
                    Console.WriteLine(errorMsg);
                }
            } while (!isValid);

            // Calculate the result
            String resultError;
            double result;
            bool success = DoOperations(operators, inputOperands, out result, out resultError);

            // If everything was good, show the result.
            if (success)
            {
                ShowResult(operators, inputOperands, result);
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
        private static void ShowResult(Operators.BinaryOperator[] operators, double[] inputOperands, double result)
        {
            // Reconstruct the input expression
            String expr = "";
            int operatorIndex;
            for (operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
            {
                // For every operator, include the operand to its left, followed by the operator.
                // The operator to the left of an operand has the same index as the operand.
                expr = String.Format("{0}{1} {2} ", expr, inputOperands[operatorIndex], operators[operatorIndex]);
            }

            // Now get the operand to the right of the last operator (which is
            // to the left of a nonexistent one-after-the-last operator). 
            // Also, include the result of the calculation.
            // Write out to the screen
            Console.WriteLine("{0}{1} = {2}", expr, inputOperands[operatorIndex], result);
        }

        /**
         * Do one or more operations, using the correct order of operations. 
         * Convenience method that doesn't need a starting and ending point 
         * (which is needed by RecurseOperations).
         */
        private static bool DoOperations(Operators.BinaryOperator[] operators, double[] inputOperands, out double result, out String errorMsg)
        {
            return RecurseOperations(operators, inputOperands, 0, operators.Length, out result, out errorMsg);
        }

        /**
         * Recursively do one or more operations, using the correct order of operations.
         * Takes a starting and stopping index to determine what portion of the tokens/operands
         * to process. startIndex is included, stopIndex is excluded.
         */
        private static bool RecurseOperations(Operators.BinaryOperator[] operators, double[] inputOperands, int startIndex, int stopIndex, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            if (startIndex == stopIndex)
            {
                // Base case, a single value
                // Result is the value of the operand to the left of the operator
                // at startIndex. This operand has the same index as the operator.
                result = inputOperands[startIndex];
                return true;
            }

            // Find the rightmost, lowest precedence operator. This allows
            // all the higher precedence operators to be evaluated (in leftResult
            // and rightResult) before we call DoOperation on this one.
            int operIndex = FindLastOperatorWithPrecedence(operators, startIndex, stopIndex);

            // Get the results for each side of the operator
            double leftResult;
            double rightResult = 0;
            bool success = (RecurseOperations(operators, inputOperands, startIndex, operIndex, out leftResult, out errorMsg) &&
                RecurseOperations(operators, inputOperands, operIndex + 1, stopIndex, out rightResult, out errorMsg));

            if (success)
            {
                // Combine the results
                success = operators[operIndex].PerformOperation(leftResult, rightResult, out result, out errorMsg);
            }

            return success;
        }

        //private static int GetLeftOperandIndexFromOperatorIndex(int operatorIndex)
        //{
        //    return operatorIndex * 2;
        //}

        
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
        private static int FindLastOperatorWithPrecedence(Operators.BinaryOperator[] operators, int startIndex, int stopIndex)
        {
            int worstPrecedence = -1;
            int worstPossiblePrecedence = Operators.BinaryOperator.WorstPrecedence;
            int worstIndex = -1;
            
            for (int i = stopIndex - 1; i >= startIndex; i--)
            {
                int precedence = operators[i].Precedence;
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

        ///**
        // * Calculate the result of a single arithmetic operation
        // */
        //private static bool DoOperation(double left, double right, Operators.BinaryOperator operatorSymbol, out double result, out String errorMsg)
        //{
        //    // Operator successful, do the operation
        //    return oper.PerformOperation(left, right, out result, out errorMsg);
        //}

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
         * Parse input into an array of operators and an array of numeric operands.
         * Each element of operands corresponds to the element to the left of the
         * same-indexed element of operators. Returns true if parsing was successful, 
         * false otherwise.
         */
        private static bool ParseInput(String inputString, out Operators.BinaryOperator[] operators, out double[] operands, out String errorMsg)
        {
            errorMsg = null;
            operands = null;
            operators = null;
            String[] tokens = inputString.Split(' ');

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
                areOperatorsValid = ConvertTokensToOperators(tokens, out operators, out errorMsg);
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
        private static string GetUserInput()
        {
            String prompt = "Please enter an expression using binary operators.\nExample expression: '75.3 + -20.7 - 35 * 6e-20'\n  > ";
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

        private static bool ConvertTokensToOperators(String[] tokens, out Operators.BinaryOperator[] operators, out String errorMsg)
        {
            errorMsg = null;

            // tokens should have an odd length. Every odd-numbered token
            // should be an operator, so there are ((tokens.Length - 1) / 2) 
            // operators. Because integer division truncates, this is the same
            // as (tokens.Length / 2).
            operators = new Operators.BinaryOperator[tokens.Length / 2];
            bool result = true;

            for (int operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
            {
                int tokenIndex = (2 * operatorIndex) + 1;
                operators[operatorIndex] = Operators.BinaryOperatorFactory.Create(tokens[tokenIndex], out errorMsg);
                if (operators[operatorIndex] == null)
                {
                    // Couldn't convert to an operator. Stop everything!
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

            // Every even-numbered token is an operand, and there are an
            // odd number of tokens.
            operands = new double[(tokens.Length + 1) / 2];

            // Each even-numbered element must be an operand.
            for (int operandIndex = 0; operandIndex < operands.Length; operandIndex++)
            {
                int tokenIndex = operandIndex * 2;
                result = double.TryParse(tokens[tokenIndex], out operands[operandIndex]);
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
