using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    abstract class AddlikeOperator : BinaryOperator
    {
        private const int _precedence = 1;
        public override int Precedence { get { return _precedence; } }

        protected enum OperandSides
        {
            LEFT, RIGHT
        }

        protected abstract int GetSignMultiplier(OperandSides side);

        protected override bool IsOperationValid(double left, double right)
        {
            double effectiveLeft = left * GetSignMultiplier(OperandSides.LEFT);
            double effectiveRight = right * GetSignMultiplier(OperandSides.RIGHT);

            // We can only overflow if both sides have the same effective sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (effectiveLeft > 0 && effectiveRight > 0)
            {
                double roomForOverflow = double.MaxValue - effectiveLeft; // non-negative
                willOverflow = (effectiveRight > roomForOverflow);
            }
            else if (effectiveLeft < 0 && effectiveRight < 0)
            {
                double roomForOverflow = double.MinValue - effectiveLeft; // non-positive
                willOverflow = (effectiveRight < roomForOverflow);
            }

            return !willOverflow; ;
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return (left * GetSignMultiplier(OperandSides.LEFT)) + (right * GetSignMultiplier(OperandSides.RIGHT));
        }
    }
}
