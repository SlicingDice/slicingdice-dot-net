using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldExceededMaxNameLenghtException : SlicingDiceException
    {
        public FieldExceededMaxNameLenghtException()
            : base() { }

        public FieldExceededMaxNameLenghtException(string message)
            : base(message) { }

        public FieldExceededMaxNameLenghtException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
