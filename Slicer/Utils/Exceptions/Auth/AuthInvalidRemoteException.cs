using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthInvalidRemoteException : SlicingDiceException
    {
        public AuthInvalidRemoteException()
            : base() { }

        public AuthInvalidRemoteException(string message)
            : base(message) { }

        public AuthInvalidRemoteException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
