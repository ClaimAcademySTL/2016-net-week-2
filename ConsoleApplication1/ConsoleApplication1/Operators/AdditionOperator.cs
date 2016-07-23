using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class AdditionOperator : AddlikeOperator
    {
        public const String OperatorSymbol = "+";
        public override String Symbol { get { return OperatorSymbol; } }

        protected override int GetSignMultiplier(AddlikeOperator.OperandSides side)
        {
            // This is pure addition, so both sides have a multiplier of 1
            return 1;
        }

        protected override string GetOverflowMessage(double left, double right)
        {
            return String.Format("Attempt to add {0} and {1}, but the result will overflow!", left, right);
        }
    }
}
