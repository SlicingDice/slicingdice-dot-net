using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryRelativeIntervalException : SlicingDiceException
    {
        public QueryRelativeIntervalException()
            : base() { }

        public QueryRelativeIntervalException(string message)
            : base(message) { }

        public QueryRelativeIntervalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
