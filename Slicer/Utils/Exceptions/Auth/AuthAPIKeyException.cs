using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthAPIKeyException : SlicingDiceException
    {
        public AuthAPIKeyException()
            : base() { }

        public AuthAPIKeyException(string message)
            : base(message) { }

        public AuthAPIKeyException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
