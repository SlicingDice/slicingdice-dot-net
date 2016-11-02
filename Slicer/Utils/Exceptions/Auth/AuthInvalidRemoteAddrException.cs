using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthInvalidRemoteAddrException : SlicingDiceException
    {
        public AuthInvalidRemoteAddrException()
            : base() { }

        public AuthInvalidRemoteAddrException(string message)
            : base(message) { }

        public AuthInvalidRemoteAddrException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
