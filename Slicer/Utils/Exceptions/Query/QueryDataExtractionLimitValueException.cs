using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionLimitValueException : SlicingDiceException
    {
        public QueryDataExtractionLimitValueException()
            : base() { }

        public QueryDataExtractionLimitValueException(string message)
            : base(message) { }

        public QueryDataExtractionLimitValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
