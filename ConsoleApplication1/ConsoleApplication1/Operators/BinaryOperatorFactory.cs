using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    static class BinaryOperatorFactory
    {
        public static BinaryOperator Create(String symbol)
        {
            switch (symbol)
            {
                case AdditionOperator.OperatorSymbol:
                    return new AdditionOperator();

                default:
                    //throw new NotImplementedException("Unrecognized operator");
                    return null;
            }
        }
    }
}
