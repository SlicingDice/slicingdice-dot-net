using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidFieldUsageException : SlicingDiceException
    {
        public QueryInvalidFieldUsageException()
            : base() { }

        public QueryInvalidFieldUsageException(string message)
            : base(message) { }

        public QueryInvalidFieldUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
