using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryFieldNotActiveException : SlicingDiceException
    {
        public QueryFieldNotActiveException()
            : base() { }

        public QueryFieldNotActiveException(string message)
            : base(message) { }

        public QueryFieldNotActiveException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
