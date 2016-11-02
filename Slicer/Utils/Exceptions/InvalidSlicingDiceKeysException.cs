using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidSlicingDiceKeysException : SlicingDiceException
    {
        public InvalidSlicingDiceKeysException()
            : base() { }

        public InvalidSlicingDiceKeysException(string message)
            : base(message) { }

        public InvalidSlicingDiceKeysException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
