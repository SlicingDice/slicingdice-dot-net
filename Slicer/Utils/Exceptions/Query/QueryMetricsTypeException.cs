using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMetricsTypeException : SlicingDiceException
    {
        public QueryMetricsTypeException()
            : base() { }

        public QueryMetricsTypeException(string message)
            : base(message) { }

        public QueryMetricsTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
