using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    interface IParser<T>
    {
        /**
         * Parse an array of input tokens into a result of type T. Returns
         * true on successful parsing, false on failure.
         */
        T Parse(String[] tokens);
    }
}
