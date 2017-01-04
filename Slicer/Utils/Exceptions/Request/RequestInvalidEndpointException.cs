using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestInvalidEndpointException : SlicingDiceException
    {
        public RequestInvalidEndpointException()
            : base() { }

        public RequestInvalidEndpointException(string message)
            : base(message) { }

        public RequestInvalidEndpointException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
