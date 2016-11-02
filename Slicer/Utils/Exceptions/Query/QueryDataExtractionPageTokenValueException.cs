using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionPageTokenValueException : SlicingDiceException
    {
        public QueryDataExtractionPageTokenValueException()
            : base() { }

        public QueryDataExtractionPageTokenValueException(string message)
            : base(message) { }

        public QueryDataExtractionPageTokenValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
