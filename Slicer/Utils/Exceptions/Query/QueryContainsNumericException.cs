using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryContainsNumericException : SlicingDiceException
    {
        public QueryContainsNumericException()
            : base() { }

        public QueryContainsNumericException(string message)
            : base(message) { }

        public QueryContainsNumericException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
