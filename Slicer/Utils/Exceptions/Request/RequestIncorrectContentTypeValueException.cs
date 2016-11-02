using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestIncorrectContentTypeValueException : SlicingDiceException
    {
        public RequestIncorrectContentTypeValueException()
            : base() { }

        public RequestIncorrectContentTypeValueException(string message)
            : base(message) { }

        public RequestIncorrectContentTypeValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
