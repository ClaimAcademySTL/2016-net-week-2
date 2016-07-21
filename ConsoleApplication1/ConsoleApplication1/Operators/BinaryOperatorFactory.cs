using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Operators
{
    static class BinaryOperatorFactory
    {
        public static BinaryOperator Create(String symbol, out String errorMsg)
        {
            errorMsg = null;

            switch (symbol)
            {
                case AdditionOperator.OperatorSymbol:
                    return new AdditionOperator();

                case SubtractionOperator.OperatorSymbol:
                    return new SubtractionOperator();

                case MultiplicationOperator.OperatorSymbol:
                    return new MultiplicationOperator();

                case DivisionOperator.OperatorSymbol:
                    return new DivisionOperator();

                case ModulusOperator.OperatorSymbol:
                    return new ModulusOperator();

                default:
                    errorMsg = String.Format("Unrecognized operator: '{0}'", symbol);
                    return null;
            }
        }
    }
}
