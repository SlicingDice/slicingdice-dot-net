using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AuthMissingHeaderException : SlicingDiceException
    {
        public AuthMissingHeaderException()
            : base() { }

        public AuthMissingHeaderException(string message)
            : base(message) { }

        public AuthMissingHeaderException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
