using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDataExtractionLimitAndPageTokenValueException : SlicingDiceException
    {
        public QueryDataExtractionLimitAndPageTokenValueException()
            : base() { }

        public QueryDataExtractionLimitAndPageTokenValueException(string message)
            : base(message) { }

        public QueryDataExtractionLimitAndPageTokenValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
