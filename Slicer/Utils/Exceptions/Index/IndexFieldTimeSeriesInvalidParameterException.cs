using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldTimeSeriesInvalidParameterException : SlicingDiceException
    {
        public IndexFieldTimeSeriesInvalidParameterException()
            : base() { }

        public IndexFieldTimeSeriesInvalidParameterException(string message)
            : base(message) { }

        public IndexFieldTimeSeriesInvalidParameterException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
