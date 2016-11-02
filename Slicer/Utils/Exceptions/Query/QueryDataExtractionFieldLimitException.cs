using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionFieldLimitException : SlicingDiceException
    {
        public QueryDataExtractionFieldLimitException()
            : base() { }

        public QueryDataExtractionFieldLimitException(string message)
            : base(message) { }

        public QueryDataExtractionFieldLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
