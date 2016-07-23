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

        private bool _hasScannedForPrecedenceRange = false;
        private int _bestPossiblePrecedence;
        private int _worstPossiblePrecedence;

        /**
         * Turns an array of operators and an array of operands into an expression.
         * operators.Length must be at least 1, and operands.Length must be exactly
         * operators.Length + 1.
         */
        public Expression(Operators.BinaryOperator[] operators, double[] operands)
        {
            if (operators.Length == 0)
            {
                throw new ArgumentException("No operators in expression!");
            }
            if (operands.Length - operators.Length != 1)
            {
                throw new ArgumentException(String.Format("Operator and operand count mismatch. For {0} operators, expected {1} operands, but found {2} operands",
                    operators.Length, operators.Length + 1, operands.Length));
            }

            _operators = operators;
            _operands = operands;
        }

        /**
         * Evaluate the expression using the correct order of operations.
         * Throws ArgumentException if any part of the expression cannot be
         * evaluated.
         */
        public virtual double Evaluate()
        {
            return RecursiveEvaluate(0, _operators.Length);
        }

        /**
         * Recursively do one or more operations, using the correct order of operations.
         * Takes a starting and stopping index to determine what portion of the tokens/operands
         * to process. startIndex is included, stopIndex is excluded. Throws ArgumentException
         * if any operation within the expression cannot be evaluated.
         */
        private double RecursiveEvaluate(int startIndex, int stopIndex)
        {
            if (startIndex == stopIndex)
            {
                // Base case, a single value
                // Result is the value of the operand to the left of the operator
                // at startIndex. This operand has the same index as the operator.
                return _operands[startIndex];
            }

            // Find the rightmost, lowest precedence operator. This allows
            // all the higher precedence operators to be evaluated (in leftResult
            // and rightResult) before we call DoOperation on this one.
            int operIndex = FindLastOperatorWithPrecedence(startIndex, stopIndex);

            // Get the results for each side of the operator. Could generate ArgumentException
            // at each of these two lines. If so, just allow it to bubble up.
            double leftResult = RecursiveEvaluate(startIndex, operIndex);
            double rightResult = RecursiveEvaluate(operIndex + 1, stopIndex);

            // Combine the results. Could generate ArgumentException
            double result = 0;
            try
            {
                result = _operators[operIndex].PerformOperation(leftResult, rightResult);
            }
            catch (ArgumentException e)
            {
                // TODO: Create an exception class that lets us show where
                // in the expression the problem occurred.
                // For now, just rethrow the original exception.
                throw e;
            }
            
            return result;
        }

        /**
         * Find the array index of operator with the lowest precedence. If there are 
         * multiple operators tying for lowest precedence, returns index of the 
         * rightmost of the tied operators.
         */
        private int FindLastOperatorWithPrecedence(int startIndex, int stopIndex)
        {
            ScanForPrecedenceRange();

            int worstPrecedence = _bestPossiblePrecedence - 1;
            int worstIndex = -1;

            for (int i = stopIndex - 1; i >= startIndex; i--)
            {
                int precedence = _operators[i].Precedence;
                if (precedence > worstPrecedence)
                {
                    worstPrecedence = precedence;
                    worstIndex = i;
                }
                if (worstPrecedence == _worstPossiblePrecedence)
                {
                    // We have the lowest possible level. No point in continuing
                    // to search.
                    break;
                }
            }

            return worstIndex;
        }

        private void ScanForPrecedenceRange()
        {
            if (_hasScannedForPrecedenceRange) return;

            bool hasLoopedOnce = false;

            foreach (Operators.BinaryOperator oper in _operators) {
                if (!hasLoopedOnce || oper.Precedence > _worstPossiblePrecedence)
                {
                    _worstPossiblePrecedence = oper.Precedence;
                }
                if (!hasLoopedOnce || oper.Precedence < _bestPossiblePrecedence)
                {
                    _bestPossiblePrecedence = oper.Precedence;
                }

                hasLoopedOnce = true;
            }
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
