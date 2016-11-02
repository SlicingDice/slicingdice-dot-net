using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidAggFilterException : SlicingDiceException
    {
        public QueryInvalidAggFilterException()
            : base() { }

        public QueryInvalidAggFilterException(string message)
            : base(message) { }

        public QueryInvalidAggFilterException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
