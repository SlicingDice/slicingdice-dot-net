using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class AccountBannedException : SlicingDiceException
    {
        public AccountBannedException()
            : base() { }

        public AccountBannedException(string message)
            : base(message) { }

        public AccountBannedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
