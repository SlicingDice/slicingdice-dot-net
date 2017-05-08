using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnExceededPermitedValueException : SlicingDiceException
    {
        public ColumnExceededPermitedValueException()
            : base() { }

        public ColumnExceededPermitedValueException(string message)
            : base(message) { }

        public ColumnExceededPermitedValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
