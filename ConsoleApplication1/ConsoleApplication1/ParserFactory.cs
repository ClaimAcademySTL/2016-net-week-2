using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class ParserFactory
    {
        static Input.IParser GetParserForTokens()
        {
            return new Expressions.ExpressionParser();
        }
    }
}
