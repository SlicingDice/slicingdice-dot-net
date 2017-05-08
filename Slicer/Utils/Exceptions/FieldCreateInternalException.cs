using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class ColumnCreateInternalException : SlicingDiceException
    {
        public ColumnCreateInternalException()
            : base() { }

        public ColumnCreateInternalException(string message)
            : base(message) { }

        public ColumnCreateInternalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
