using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTimeSeriesException : SlicingDiceException
    {
        public QueryTimeSeriesException()
            : base() { }

        public QueryTimeSeriesException(string message)
            : base(message) { }

        public QueryTimeSeriesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
