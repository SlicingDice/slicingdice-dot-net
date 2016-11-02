using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidOperatorException : SlicingDiceException
    {
        public QueryInvalidOperatorException()
            : base() { }

        public QueryInvalidOperatorException(string message)
            : base(message) { }

        public QueryInvalidOperatorException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
