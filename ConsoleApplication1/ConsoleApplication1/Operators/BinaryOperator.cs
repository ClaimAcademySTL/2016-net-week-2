using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    abstract class BinaryOperator
    {
        public const int WorstPrecedence = 1;

        /**
         * The symbol representing this operation ("+" for addition, etc.)
         */
        public abstract String Symbol { get; }

        /**
         * An integer representing this operator's precedence in the order
         * of operations. A lower number corresponds to a higher precedence
         * (that is, the operators with the lowest integer are evaluated first,
         * left-to-right, followed by the operators with the next-lowest
         * integer, etc.).
         */
        public abstract int Precedence { get; }

        /**
         * Perform the operation, as long as it is valid and will not overflow.
         * result is the result of the operation. Returns true on success, false
         * if the operation is not valid on the given parameters or would overflow.
         */
        public bool PerformOperation(double left, double right, out double result, out String errorMsg)
        {
            result = 0;
            bool success;
            if (IsOperationValid(left, right, out errorMsg))
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

        public override string ToString()
        {
            return Symbol;
        }

        /**
         * Return true if the operation can be validly performed with the given
         * parameters, false otherwise.
         */
        protected abstract bool IsOperationValid(double left, double right, out String errorMsg);

        /**
         * Perform the operation, assuming any error/bounds checking has already
         * been done.
         */
        protected abstract double PerformOperationWithoutChecking(double left, double right);

        
    }
}
