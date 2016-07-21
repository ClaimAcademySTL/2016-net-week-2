using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class DivisionOperator : MultiplylikeOperator
    {
        public const String OperatorSymbol = "/";
        public override string Symbol { get { return OperatorSymbol; } }

        protected override bool IsOperationValid(double left, double right, out String errorMsg)
        {
            bool success;
            if (right == 0)
            {
                success = false;
                errorMsg = "Attempt to divide by zero!";
            }
            else
            {
                
                success = true;
                errorMsg = null;
            }
            return success;
        }

        protected override double PerformOperationWithoutChecking(double left, double right)
        {
            return left / right;
        }
    }
}
