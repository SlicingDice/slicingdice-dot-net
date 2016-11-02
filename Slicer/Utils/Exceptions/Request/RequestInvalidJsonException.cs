using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestInvalidJsonException : SlicingDiceException
    {
        public RequestInvalidJsonException()
            : base() { }

        public RequestInvalidJsonException(string message)
            : base(message) { }

        public RequestInvalidJsonException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
