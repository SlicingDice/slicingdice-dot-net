using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryFieldLimitException : SlicingDiceException
    {
        public QueryFieldLimitException()
            : base() { }

        public QueryFieldLimitException(string message)
            : base(message) { }

        public QueryFieldLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
