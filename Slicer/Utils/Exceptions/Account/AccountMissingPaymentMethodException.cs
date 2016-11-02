using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AccountMissingPaymentMethodException : SlicingDiceException
    {
        public AccountMissingPaymentMethodException()
            : base() { }

        public AccountMissingPaymentMethodException(string message)
            : base(message) { }

        public AccountMissingPaymentMethodException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
