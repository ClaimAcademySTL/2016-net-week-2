using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    class SubtractionOperator : AddlikeOperator
    {
        public const String OperatorSymbol = "-";
        public override string Symbol { get { return OperatorSymbol; } }

        protected override int GetSignMultiplier(OperandSides side)
        {
            switch (side)
            {
                case OperandSides.LEFT:
                    return 1;

                case OperandSides.RIGHT:
                    return -1;

                default:
                    return 0;
            }
        }
    }
}
