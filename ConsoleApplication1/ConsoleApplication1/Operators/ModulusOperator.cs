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

        /**
         * Operation is only considered invalid if right parameter is zero.
         */
        protected override void TestOperation(double left, double right)
        {
            if (right == 0)
            {
                throw new ArgumentException("Attempt to get remainder of division by zero!");
            }
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return left % right;
        }
    }
}
