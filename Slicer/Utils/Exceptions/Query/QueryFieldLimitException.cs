using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryColumnLimitException : SlicingDiceException
    {
        public QueryColumnLimitException()
            : base() { }

        public QueryColumnLimitException(string message)
            : base(message) { }

        public QueryColumnLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
