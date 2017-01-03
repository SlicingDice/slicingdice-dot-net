using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidOperatorUsageException : SlicingDiceException
    {
        public QueryInvalidOperatorUsageException()
            : base() { }

        public QueryInvalidOperatorUsageException(string message)
            : base(message) { }

        public QueryInvalidOperatorUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
