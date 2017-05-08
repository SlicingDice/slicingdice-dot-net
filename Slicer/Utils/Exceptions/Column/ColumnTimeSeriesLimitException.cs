using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnTimeSeriesLimitException : SlicingDiceException
    {
        public ColumnTimeSeriesLimitException()
            : base() { }

        public ColumnTimeSeriesLimitException(string message)
            : base(message) { }

        public ColumnTimeSeriesLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
