using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryDateFormatException : SlicingDiceException
    {
        public QueryDateFormatException()
            : base() { }

        public QueryDateFormatException(string message)
            : base(message) { }

        public QueryDateFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
