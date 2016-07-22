using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class MultiplicationOperator : MultiplylikeOperator
    {
        public const String OperatorSymbol = "*";
        public override string Symbol { get { return OperatorSymbol; } }

        /**
         * Precision could be lost without returning false (for example, when adding 
         * two numbers that each have a very small magnitude, the result could be 0).
         */
        protected override bool IsOperationValid(double left, double right, out String errorMsg)
        {
            bool willOverflow = false;
            // Can't overflow if absolute value of either 
            // operand is less than 1.
            // Can overflow past MaxValue if both signs
            // are the same, or past MinValue if both
            // operands have opposite sign.
            if ((left < -1 || left > 1) && (right < -1 || right > 1))
            {
                double absA, absB;
                int signA = GetSign(left, out absA);
                int signB = GetSign(right, out absB);
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

            if (willOverflow)
            {
                errorMsg = "Multiplication will overflow!";
            }
            else
            {
                errorMsg = null;
            }

            return !willOverflow;
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return left * right;
        }
    }
}
