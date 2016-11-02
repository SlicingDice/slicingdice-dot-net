using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AccountPaymentRequiredException : SlicingDiceException
    {
        public AccountPaymentRequiredException()
            : base() { }

        public AccountPaymentRequiredException(string message)
            : base(message) { }

        public AccountPaymentRequiredException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
