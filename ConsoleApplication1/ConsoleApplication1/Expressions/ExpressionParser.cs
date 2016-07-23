using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Input;

namespace ConsoleApplication1.Expressions
{
    class ExpressionParser : IParser<Expression>
    {
        private String[] _tokens;

        /**
         * Parse input tokens into an Expression. Throws ArgumentException if
         * tokens cannot contain a valid expression due to its length. Throws
         * BadTokenException if not all operators and operands are valid.
         */
        public Expression Parse(String[] tokens)
        {
            _tokens = tokens;

            // Throws ArgumentException if length is invalid
            CheckTokenCount();

            // Throws BadTokenException if an invalid operator is found
            Operators.BinaryOperator[] operators = ConvertTokensToOperators();
            
            // Throws BadTokenException if an invalid operand is found
            double[] operands = ConvertTokensToOperands();
            
            return new Expression(operators, operands);
        }

        /**
         * Do nothing if _tokens has a valid length, or throw an ArgumentException
         * if the length is invalid.
         */
        private void CheckTokenCount()
        {
            // Must have an odd number of tokens, with at least 3, or else
            // we don't have a series of binary operators.

            if (_tokens.Length <= 2)
            {
                throw new ArgumentException(String.Format("Not enough tokens. Expected at least 3, found {0}", _tokens.Length));
            }

            if (_tokens.Length % 2 == 0)
            {
                throw new ArgumentException("Should have an odd number of tokens, but have an even number.");
            }
        }

        /**
         * Throws a BadTokenException if an operator can't be converted
         */
        private Operators.BinaryOperator[] ConvertTokensToOperators()
        {
            // tokens should have an odd length. Every odd-numbered token
            // should be an operator, so there are ((tokens.Length - 1) / 2) 
            // operators. Because integer division truncates, this is the same
            // as (tokens.Length / 2).
            Operators.BinaryOperator[] operators = new Operators.BinaryOperator[_tokens.Length / 2];

            for (int operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
            {
                int tokenIndex = (2 * operatorIndex) + 1;
                try
                {
                    operators[operatorIndex] = Operators.BinaryOperatorFactory.Create(_tokens[tokenIndex]);
                }
                catch (ArgumentException e)
                {
                    // Couldn't convert to an operator. Convert the exception to a
                    // BadTokenException, which lets us indicate which token was
                    // bad.
                    throw new BadTokenException(tokenIndex, e.Message, e);
                    
                }
            }

            return operators;
        }

        /**
         * Convert all the numeric operands in the String array _tokens from
         * Strings to doubles. Returns true if successful, false otherwise.
         */
        private double[] ConvertTokensToOperands()
        {
            // Every even-numbered token is an operand, and there are an
            // odd number of tokens.
            double[] operands = new double[(_tokens.Length + 1) / 2];

            // Each even-numbered element must be an operand.
            for (int operandIndex = 0; operandIndex < operands.Length; operandIndex++)
            {
                int tokenIndex = operandIndex * 2;
                try
                {
                    operands[operandIndex] = double.Parse(_tokens[tokenIndex]);
                }
                catch (FormatException e)
                {
                    throw new BadTokenException(tokenIndex, String.Format("'{0}' is not a valid number!", _tokens[tokenIndex]), e);
                }
            }

            return operands;
        }
    }
}
