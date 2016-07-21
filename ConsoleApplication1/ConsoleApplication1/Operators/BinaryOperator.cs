using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    abstract class BinaryOperator
    {
        public abstract String Symbol { get; }
        public abstract int Precedence { get; }

        public bool PerformOperation(double left, double right, out double result)
        {
            result = 0;
            bool success;
            if (IsOperationValid(left, right))
            {
                success = true;
                result = PerformOperationWithoutChecking(left, right);
            }
            else
            {
                success = false;
            }

            return success;
        }

        protected abstract bool IsOperationValid(double left, double right);
        protected abstract double PerformOperationWithoutChecking(double left, double right);
    }
}
