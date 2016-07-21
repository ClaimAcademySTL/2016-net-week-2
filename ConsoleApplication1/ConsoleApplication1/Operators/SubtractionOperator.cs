using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class SubtractionOperator : BinaryOperator
    {
        public const String OperatorSymbol = "-";
        private const int _precedence = 1;

        public override int Precedence { get { return _precedence; } }

        public override string Symbol { get { return OperatorSymbol; } }

        protected override bool IsOperationValid(double left, double right)
        {
            // We can only overflow if both a and b have opposite sign
            // (and both are non-zero).
            bool willOverflow = false;
            int left = 0;
            int b = 0;
            if (left > 0 && b < 0)
            {
                double roomForOverflow = double.MaxValue - left; // non-negative
                willOverflow = (b < -roomForOverflow);
            }
            else if (left < 0 && b > 0)
            {
                double roomForOverflow = double.MinValue - left; // non-positive
                willOverflow = (b > -roomForOverflow);
            }

            return !willOverflow;
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            throw new NotImplementedException();
        }
    }
}
