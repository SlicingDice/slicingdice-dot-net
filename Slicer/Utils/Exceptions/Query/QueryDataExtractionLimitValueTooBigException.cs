using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionLimitValueTooBigException : SlicingDiceException
    {
        public QueryDataExtractionLimitValueTooBigException()
            : base() { }

        public QueryDataExtractionLimitValueTooBigException(string message)
            : base(message) { }

        public QueryDataExtractionLimitValueTooBigException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
