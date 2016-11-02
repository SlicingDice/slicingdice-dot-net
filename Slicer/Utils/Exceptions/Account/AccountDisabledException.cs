using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AccountDisabledException : SlicingDiceException
    {
        public AccountDisabledException()
            : base() { }

        public AccountDisabledException(string message)
            : base(message) { }

        public AccountDisabledException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
