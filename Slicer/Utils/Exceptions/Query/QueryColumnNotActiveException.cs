using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryColumnNotActiveException : SlicingDiceException
    {
        public QueryColumnNotActiveException()
            : base() { }

        public QueryColumnNotActiveException(string message)
            : base(message) { }

        public QueryColumnNotActiveException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
