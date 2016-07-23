using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    abstract class BinaryOperator
    {
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
         * result is the result of the operation. Throws ArgumentException
         * if the operation is not valid on the given parameters or would overflow.
         */
        public double PerformOperation(double left, double right)
        {
            // Throws ArgumentException if not valid
            TestOperation(left, right);

            return PerformOperationWithoutChecking(left, right);
        }

        public override string ToString()
        {
            return Symbol;
        }

        /**
         * Throw ArgumentException if this operation would not be valid with the given parameters.
         */
        protected abstract void TestOperation(double left, double right);

        /**
         * Perform the operation, assuming any error/bounds checking has already
         * been done.
         */
        protected abstract double PerformOperationWithoutChecking(double left, double right);

        
    }
}
