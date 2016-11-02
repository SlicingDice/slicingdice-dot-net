using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class FieldCreateInternalException : SlicingDiceException
    {
        public FieldCreateInternalException()
            : base() { }

        public FieldCreateInternalException(string message)
            : base(message) { }

        public FieldCreateInternalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
