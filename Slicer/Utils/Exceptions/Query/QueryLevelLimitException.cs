using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryLevelLimitException : SlicingDiceException
    {
        public QueryLevelLimitException()
            : base() { }

        public QueryLevelLimitException(string message)
            : base(message) { }

        public QueryLevelLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
