using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMetricsLevelException : SlicingDiceException
    {
        public QueryMetricsLevelException()
            : base() { }

        public QueryMetricsLevelException(string message)
            : base(message) { }

        public QueryMetricsLevelException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
