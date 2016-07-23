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

        /**
         * Return the effective sign for each operand side needed to
         * convert this operation into pure addition. Return -1 for 
         * negative, or 1 for positive (for example, subtracting
         * a - b is the same as adding a + -b, so subtraction would return
         * -1 for the right side). A subclass could legally return other 
         * multipliers besides -1 and 1, but this would result in odd
         * behavior
         */
        protected abstract int GetSignMultiplier(OperandSides side);

        /**
         * Precision could be lost without returning false (for example, when adding 
         * two numbers which greatly differ in magnitude).
         */
        protected override void TestOperation(double left, double right)
        {
            double effectiveLeft = left * GetSignMultiplier(OperandSides.LEFT);
            double effectiveRight = right * GetSignMultiplier(OperandSides.RIGHT);

            // We can only overflow if both sides have the same effective sign
            // (and both are non-zero).
            bool willOverflow = false;
            if (effectiveLeft > 0 && effectiveRight > 0)
            {
                double roomForOverflow = double.MaxValue - effectiveLeft; // non-negative
                // effectiveRight and roomForOverflow are both non-negative. Overflow if
                // effectiveRight is more positive than roomForOverflow.
                willOverflow = (effectiveRight > roomForOverflow);
            }
            else if (effectiveLeft < 0 && effectiveRight < 0)
            {
                double roomForOverflow = double.MinValue - effectiveLeft; // non-positive
                // effectiveRight and roomForOverflow are both non-positive. Overflow if
                // effectiveRight is more negative than roomForOverflow.
                willOverflow = (effectiveRight < roomForOverflow);
            }

            if (willOverflow)
            {
                throw new ArgumentException(GetOverflowMessage(left, right));
            }
        }

        protected virtual String GetOverflowMessage(double left, double right)
        {
            return "Arithmetic overflow!";
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return (left * GetSignMultiplier(OperandSides.LEFT)) + (right * GetSignMultiplier(OperandSides.RIGHT));
        }
    }
}
