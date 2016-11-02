using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryContainsValueTypeException : SlicingDiceException
    {
        public QueryContainsValueTypeException()
            : base() { }

        public QueryContainsValueTypeException(string message)
            : base(message) { }

        public QueryContainsValueTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
