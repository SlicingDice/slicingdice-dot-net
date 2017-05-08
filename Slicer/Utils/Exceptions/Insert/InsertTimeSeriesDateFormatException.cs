using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertTimeSeriesDateFormatException : SlicingDiceException
    {
        public InsertTimeSeriesDateFormatException()
            : base() { }

        public InsertTimeSeriesDateFormatException(string message)
            : base(message) { }

        public InsertTimeSeriesDateFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
