using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    abstract class MultiplylikeOperator : BinaryOperator
    {
        private const int _precedence = 0;
        public override int Precedence { get { return _precedence; } }

        /**
         * Get the sign and absolute value of val. Return 1 for positive,
         * -1 for negative, or 0 for 0.
         */
        protected int GetSign(double val, out double absoluteValue)
        {
            int sign;
            if (val > 0)
            {
                sign = 1;
            }
            else if (val < 0)
            {
                sign = -1;
            }
            else
            {
                sign = 0;
            }
            absoluteValue = val * sign;
            return sign;
        }
    }
}
