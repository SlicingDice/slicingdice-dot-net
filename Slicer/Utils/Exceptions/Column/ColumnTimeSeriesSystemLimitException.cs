using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnTimeSeriesSystemLimitException : SlicingDiceException
    {
        public ColumnTimeSeriesSystemLimitException()
            : base() { }

        public ColumnTimeSeriesSystemLimitException(string message)
            : base(message) { }

        public ColumnTimeSeriesSystemLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
