using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldExceededPermitedValueException : SlicingDiceException
    {
        public FieldExceededPermitedValueException()
            : base() { }

        public FieldExceededPermitedValueException(string message)
            : base(message) { }

        public FieldExceededPermitedValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
