using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryParameterInvalidColumnUsageException : SlicingDiceException
    {
        public QueryParameterInvalidColumnUsageException()
            : base() { }

        public QueryParameterInvalidColumnUsageException(string message)
            : base(message) { }

        public QueryParameterInvalidColumnUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
