using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestInvalidHttpMethodException : SlicingDiceException
    {
        public RequestInvalidHttpMethodException()
            : base() { }

        public RequestInvalidHttpMethodException(string message)
            : base(message) { }

        public RequestInvalidHttpMethodException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
