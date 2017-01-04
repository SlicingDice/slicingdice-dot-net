using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestIncorrectHttpException : SlicingDiceException
    {
        public RequestIncorrectHttpException()
            : base() { }

        public RequestIncorrectHttpException(string message)
            : base(message) { }

        public RequestIncorrectHttpException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
