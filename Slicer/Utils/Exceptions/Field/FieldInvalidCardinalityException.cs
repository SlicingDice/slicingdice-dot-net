using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldInvalidCardinalityException : SlicingDiceException
    {
        public FieldInvalidCardinalityException()
            : base() { }

        public FieldInvalidCardinalityException(string message)
            : base(message) { }

        public FieldInvalidCardinalityException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
