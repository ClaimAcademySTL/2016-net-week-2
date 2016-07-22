using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Expressions
{
    class Expression
    {
        private readonly Operators.BinaryOperator[] _operators;
        private readonly double[] _operands;

        public Expression(Operators.BinaryOperator[] operators, double[] operands)
        {
            _operators = operators;
            _operands = operands;
        }

        public virtual bool Evaluate(out double result, out String errorMsg)
        {
            return RecursiveEvaluate(0, _operators.Length, out result, out errorMsg);
        }

        /**
         * Recursively do one or more operations, using the correct order of operations.
         * Takes a starting and stopping index to determine what portion of the tokens/operands
         * to process. startIndex is included, stopIndex is excluded.
         */
        private bool RecursiveEvaluate(int startIndex, int stopIndex, out double result, out String errorMsg)
        {
            errorMsg = null;
            result = 0;
            if (startIndex == stopIndex)
            {
                // Base case, a single value
                // Result is the value of the operand to the left of the operator
                // at startIndex. This operand has the same index as the operator.
                result = _operands[startIndex];
                return true;
            }

            // Find the rightmost, lowest precedence operator. This allows
            // all the higher precedence operators to be evaluated (in leftResult
            // and rightResult) before we call DoOperation on this one.
            int operIndex = FindLastOperatorWithPrecedence(startIndex, stopIndex);

            // Get the results for each side of the operator
            double leftResult;
            double rightResult = 0;
            bool success = (RecursiveEvaluate(startIndex, operIndex, out leftResult, out errorMsg) &&
                RecursiveEvaluate(operIndex + 1, stopIndex, out rightResult, out errorMsg));

            if (success)
            {
                // Combine the results
                success = _operators[operIndex].PerformOperation(leftResult, rightResult, out result, out errorMsg);
            }

            return success;
        }

        /**
         * Find the array index of operator with the lowest precedence. If there are 
         * multiple operators tying for lowest precedence, returns index of the 
         * rightmost of the tied operators.
         */
        private int FindLastOperatorWithPrecedence(int startIndex, int stopIndex)
        {
            int worstPrecedence = -1;
            int worstPossiblePrecedence = Operators.BinaryOperator.WorstPrecedence;
            int worstIndex = -1;

            for (int i = stopIndex - 1; i >= startIndex; i--)
            {
                int precedence = _operators[i].Precedence;
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

        public override string ToString()
        {
            // Reconstruct the input expression

            String result = "";
            int operatorIndex;
            for (operatorIndex = 0; operatorIndex < _operators.Length; operatorIndex++)
            {
                // For every operator, include the operand to its left, followed by the operator.
                // The operator to the left of an operand has the same index as the operand.
                result = String.Format("{0}{1} {2} ", result, _operands[operatorIndex], _operators[operatorIndex]);
            }

            // Now get the operand to the right of the last operator (which is
            // to the left of a nonexistent one-after-the-last operator). 
            result = String.Format("{0}{1}", result, _operands[operatorIndex]);

            return result;
        }
    }
}
