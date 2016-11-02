using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryIntegerException : SlicingDiceException
    {
        public QueryIntegerException()
            : base() { }

        public QueryIntegerException(string message)
            : base(message) { }

        public QueryIntegerException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
