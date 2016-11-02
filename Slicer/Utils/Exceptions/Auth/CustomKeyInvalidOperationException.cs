using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyInvalidOperationException : SlicingDiceException
    {
        public CustomKeyInvalidOperationException()
            : base() { }

        public CustomKeyInvalidOperationException(string message)
            : base(message) { }

        public CustomKeyInvalidOperationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
