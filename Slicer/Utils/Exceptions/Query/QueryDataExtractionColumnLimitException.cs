using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionColumnLimitException : SlicingDiceException
    {
        public QueryDataExtractionColumnLimitException()
            : base() { }

        public QueryDataExtractionColumnLimitException(string message)
            : base(message) { }

        public QueryDataExtractionColumnLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
