using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldInvalidDescriptionException : SlicingDiceException
    {
        public FieldInvalidDescriptionException()
            : base() { }

        public FieldInvalidDescriptionException(string message)
            : base(message) { }

        public FieldInvalidDescriptionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
