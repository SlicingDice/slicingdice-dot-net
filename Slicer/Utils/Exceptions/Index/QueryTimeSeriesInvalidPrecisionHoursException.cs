using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTimeSeriesInvalidPrecisionHoursException : SlicingDiceException
    {
        public QueryTimeSeriesInvalidPrecisionHoursException()
            : base() { }

        public QueryTimeSeriesInvalidPrecisionHoursException(string message)
            : base(message) { }

        public QueryTimeSeriesInvalidPrecisionHoursException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
