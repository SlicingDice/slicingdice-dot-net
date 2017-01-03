using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexTimeSeriesDateFormatException : SlicingDiceException
    {
        public IndexTimeSeriesDateFormatException()
            : base() { }

        public IndexTimeSeriesDateFormatException(string message)
            : base(message) { }

        public IndexTimeSeriesDateFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
