using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class InternalException : SlicingDiceException
    {
        public InternalException()
            : base() { }

        public InternalException(string message)
            : base(message) { }

        public InternalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
