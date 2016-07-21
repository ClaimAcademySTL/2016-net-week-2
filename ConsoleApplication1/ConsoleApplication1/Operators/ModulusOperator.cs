using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class ModulusOperator : MultiplylikeOperator
    {
        public const String OperatorSymbol = "%";
        public override string Symbol { get { return OperatorSymbol; } }

        protected override bool IsOperationValid(double left, double right, out String errorMsg)
        {
            bool willOverflow = false;
            // Can't overflow if first operand is 0.
            // Can only overflow if absolute value of first
            // operand is greater than 1 and absolute value
            // of second operand is less than 1.
            // Can overflow past MaxValue if both signs
            // are the same, or past MinValue if both
            // operands have opposite sign.
            if ((left < -1 || left > 1) && (right > -1 && right < 1))
            {
                double absA, absB;
                int signA = GetSign(left, out absA);
                int signB = GetSign(right, out absB);
                if (signA == signB)
                {
                    willOverflow = (absA > absB * double.MaxValue);
                }
                else
                {
                    willOverflow = (absA > -absB * double.MinValue);
                }
            }

            if (willOverflow)
            {
                errorMsg = "Division overflow!";
            }
            else
            {
                errorMsg = null;
            }

            return !willOverflow;
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return left % right;
        }
    }
}
