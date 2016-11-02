using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryCountInvalidParameterException : SlicingDiceException
    {
        public QueryCountInvalidParameterException()
            : base() { }

        public QueryCountInvalidParameterException(string message)
            : base(message) { }

        public QueryCountInvalidParameterException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
