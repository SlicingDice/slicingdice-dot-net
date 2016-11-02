using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMissingOperatorException : SlicingDiceException
    {
        public QueryMissingOperatorException()
            : base() { }

        public QueryMissingOperatorException(string message)
            : base(message) { }

        public QueryMissingOperatorException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
