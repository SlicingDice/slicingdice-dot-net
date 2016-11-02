using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryEventCountQueryException : SlicingDiceException
    {
        public QueryEventCountQueryException()
            : base() { }

        public QueryEventCountQueryException(string message)
            : base(message) { }

        public QueryEventCountQueryException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
