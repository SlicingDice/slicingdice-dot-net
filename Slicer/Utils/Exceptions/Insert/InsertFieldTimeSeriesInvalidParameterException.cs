using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldTimeSeriesInvalidParameterException : SlicingDiceException
    {
        public InsertFieldTimeSeriesInvalidParameterException()
            : base() { }

        public InsertFieldTimeSeriesInvalidParameterException(string message)
            : base(message) { }

        public InsertFieldTimeSeriesInvalidParameterException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
