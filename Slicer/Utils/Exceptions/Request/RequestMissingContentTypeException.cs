using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestMissingContentTypeException : SlicingDiceException
    {
        public RequestMissingContentTypeException()
            : base() { }

        public RequestMissingContentTypeException(string message)
            : base(message) { }

        public RequestMissingContentTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
