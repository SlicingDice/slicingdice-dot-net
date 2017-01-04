using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryExceededMaxNumberQuerysException : SlicingDiceException
    {
        public QueryExceededMaxNumberQuerysException()
            : base() { }

        public QueryExceededMaxNumberQuerysException(string message)
            : base(message) { }

        public QueryExceededMaxNumberQuerysException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
