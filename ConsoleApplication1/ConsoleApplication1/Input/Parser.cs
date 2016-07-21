using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class Parser
    {
        private String[] _tokens;

        /**
         * Parse input into an array of operators and an array of numeric operands.
         * Each element of operands corresponds to the element to the left of the
         * same-indexed element of operators. Returns true if parsing was successful, 
         * false otherwise.
         */
        public bool Parse(String[] tokens, out Operators.BinaryOperator[] operators, out double[] operands, out String errorMsg)
        {
            errorMsg = null;
            operands = null;
            operators = null;

            _tokens = tokens;

            
            bool isLengthValid = CheckTokenCount();
            if (!isLengthValid)
            {
                errorMsg = "Invalid number of tokens. Expression is not a series of binary operators with operands.";
            }
            bool areOperatorsValid = false;
            bool areOperandsValid = false;
            if (isLengthValid)
            {
                areOperatorsValid = ConvertTokensToOperators(out operators, out errorMsg);
            }
            if (areOperatorsValid)
            {
                areOperandsValid = ConvertTokensToOperands(out operands, out errorMsg);
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
         * Convert all the numeric operands in the String array tokens from
         * Strings to doubles. Odd-numbered elements of the out array operands
         * are 0.0 and should be ignored. Each even-numbered index in operands
         * holds the value corresponding to the same index in tokens. Returns 
         * true if successful, false otherwise.
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
