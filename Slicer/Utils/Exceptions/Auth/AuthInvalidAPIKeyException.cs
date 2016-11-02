using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthInvalidAPIKeyException : SlicingDiceException
    {
        public AuthInvalidAPIKeyException()
            : base() { }

        public AuthInvalidAPIKeyException(string message)
            : base(message) { }

        public AuthInvalidAPIKeyException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
