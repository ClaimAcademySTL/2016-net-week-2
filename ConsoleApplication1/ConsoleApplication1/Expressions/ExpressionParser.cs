﻿using System;
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
         * Parse input tokens into an Expression. Returns true if parsing was 
         * successful, false otherwise.
         */
        public bool Parse(String[] tokens, out Expression expr, out String errorMsg)
        {
            errorMsg = null;
            expr = null;

            _tokens = tokens;

            bool isLengthValid = CheckTokenCount();
            if (!isLengthValid)
            {
                errorMsg = "Invalid number of tokens. Expression is not a series of binary operators with operands.";
            }
            bool areOperatorsValid = false;
            bool areOperandsValid = false;
            Operators.BinaryOperator[] operators = null;
            if (isLengthValid)
            {
                areOperatorsValid = ConvertTokensToOperators(out operators, out errorMsg);
            }
            double[] operands = null;
            if (areOperatorsValid)
            {
                areOperandsValid = ConvertTokensToOperands(out operands, out errorMsg);
            }

            if (areOperandsValid)
            {
                expr = new Expression(operators, operands);
            }

            return areOperandsValid;
        }

        private bool CheckTokenCount()
        {
            // Must have an odd number of tokens, with at least 3, or else
            // we don't have a series of binary operators.
            return (_tokens.Length > 2 && _tokens.Length % 2 == 1);
        }

        private bool ConvertTokensToOperators(out Operators.BinaryOperator[] operators, out String errorMsg)
        {
            errorMsg = null;

            // tokens should have an odd length. Every odd-numbered token
            // should be an operator, so there are ((tokens.Length - 1) / 2) 
            // operators. Because integer division truncates, this is the same
            // as (tokens.Length / 2).
            operators = new Operators.BinaryOperator[_tokens.Length / 2];
            bool result = true;

            for (int operatorIndex = 0; operatorIndex < operators.Length; operatorIndex++)
            {
                int tokenIndex = (2 * operatorIndex) + 1;
                operators[operatorIndex] = Operators.BinaryOperatorFactory.Create(_tokens[tokenIndex], out errorMsg);
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
         * Convert all the numeric operands in the String array _tokens from
         * Strings to doubles. Returns true if successful, false otherwise.
         */
        private bool ConvertTokensToOperands(out double[] operands, out String errorMsg)
        {
            errorMsg = null;
            bool result = false;

            // Every even-numbered token is an operand, and there are an
            // odd number of tokens.
            operands = new double[(_tokens.Length + 1) / 2];

            // Each even-numbered element must be an operand.
            for (int operandIndex = 0; operandIndex < operands.Length; operandIndex++)
            {
                int tokenIndex = operandIndex * 2;
                result = double.TryParse(_tokens[tokenIndex], out operands[operandIndex]);
                if (!result)
                {
                    // Not a valid operand. No need to continue checking.
                    errorMsg = String.Format("'{0}' is not a valid number!", _tokens[tokenIndex]);
                    break;
                }

            }

            return result;
        }
    }
}
