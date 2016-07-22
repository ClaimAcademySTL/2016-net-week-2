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

        
    }
}
