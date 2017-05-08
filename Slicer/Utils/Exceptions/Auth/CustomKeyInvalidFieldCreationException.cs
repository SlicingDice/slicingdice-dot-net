using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyInvalidColumnCreationException : SlicingDiceException
    {
        public CustomKeyInvalidColumnCreationException()
            : base() { }

        public CustomKeyInvalidColumnCreationException(string message)
            : base(message) { }

        public CustomKeyInvalidColumnCreationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
