using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidMetricException : SlicingDiceException
    {
        public QueryInvalidMetricException()
            : base() { }

        public QueryInvalidMetricException(string message)
            : base(message) { }

        public QueryInvalidMetricException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
