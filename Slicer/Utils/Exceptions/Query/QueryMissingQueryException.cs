using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMissingQueryException : SlicingDiceException
    {
        public QueryMissingQueryException()
            : base() { }

        public QueryMissingQueryException(string message)
            : base(message) { }

        public QueryMissingQueryException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
