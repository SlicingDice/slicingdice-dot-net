using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidColumnUsageException : SlicingDiceException
    {
        public QueryInvalidColumnUsageException()
            : base() { }

        public QueryInvalidColumnUsageException(string message)
            : base(message) { }

        public QueryInvalidColumnUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
