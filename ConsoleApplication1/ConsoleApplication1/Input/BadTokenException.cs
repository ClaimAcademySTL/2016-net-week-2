using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Input
{
    class BadTokenException : FormatException
    {
        public int IndexOfBadToken { get; }

        public BadTokenException(String msg, Exception innerException = null) : this(-1, msg, innerException) { }

        public BadTokenException(int tokenIndex = -1, String msg = null, Exception innerException = null) 
            : base(msg, innerException)
        {
            IndexOfBadToken = tokenIndex;
        }
    }
}
