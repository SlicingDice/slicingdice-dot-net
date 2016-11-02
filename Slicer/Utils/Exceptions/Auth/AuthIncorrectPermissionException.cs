using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthIncorrectPermissionException : SlicingDiceException
    {
        public AuthIncorrectPermissionException()
            : base() { }

        public AuthIncorrectPermissionException(string message)
            : base(message) { }

        public AuthIncorrectPermissionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
