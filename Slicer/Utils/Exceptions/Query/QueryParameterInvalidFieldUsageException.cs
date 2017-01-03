using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryParameterInvalidFieldUsageException : SlicingDiceException
    {
        public QueryParameterInvalidFieldUsageException()
            : base() { }

        public QueryParameterInvalidFieldUsageException(string message)
            : base(message) { }

        public QueryParameterInvalidFieldUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
