using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTimeSeriesInvalidPrecisionSecondsException : SlicingDiceException
    {
        public QueryTimeSeriesInvalidPrecisionSecondsException()
            : base() { }

        public QueryTimeSeriesInvalidPrecisionSecondsException(string message)
            : base(message) { }

        public QueryTimeSeriesInvalidPrecisionSecondsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
