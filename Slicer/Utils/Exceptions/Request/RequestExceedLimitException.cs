using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestExceedLimitException : SlicingDiceException
    {
        public RequestExceedLimitException()
            : base() { }

        public RequestExceedLimitException(string message)
            : base(message) { }

        public RequestExceedLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
