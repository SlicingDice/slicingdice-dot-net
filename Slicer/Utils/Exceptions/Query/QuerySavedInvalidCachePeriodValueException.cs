using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedInvalidCachePeriodValueException : SlicingDiceException
    {
        public QuerySavedInvalidCachePeriodValueException()
            : base() { }

        public QuerySavedInvalidCachePeriodValueException(string message)
            : base(message) { }

        public QuerySavedInvalidCachePeriodValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
