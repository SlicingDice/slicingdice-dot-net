using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTimeSeriesInvalidPrecisionMinutesException : SlicingDiceException
    {
        public QueryTimeSeriesInvalidPrecisionMinutesException()
            : base() { }

        public QueryTimeSeriesInvalidPrecisionMinutesException(string message)
            : base(message) { }

        public QueryTimeSeriesInvalidPrecisionMinutesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
