using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldTimeSeriesSystemLimitException : SlicingDiceException
    {
        public FieldTimeSeriesSystemLimitException()
            : base() { }

        public FieldTimeSeriesSystemLimitException(string message)
            : base(message) { }

        public FieldTimeSeriesSystemLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
