using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldInvalidApiNameException : SlicingDiceException
    {
        public FieldInvalidApiNameException()
            : base() { }

        public FieldInvalidApiNameException(string message)
            : base(message) { }

        public FieldInvalidApiNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
