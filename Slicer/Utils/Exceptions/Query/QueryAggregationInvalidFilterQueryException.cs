using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryAggregationInvalidFilterQueryException : SlicingDiceException
    {
        public QueryAggregationInvalidFilterQueryException()
            : base() { }

        public QueryAggregationInvalidFilterQueryException(string message)
            : base(message) { }

        public QueryAggregationInvalidFilterQueryException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
