using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldExceedDescriptionlengthException : SlicingDiceException
    {
        public FieldExceedDescriptionlengthException()
            : base() { }

        public FieldExceedDescriptionlengthException(string message)
            : base(message) { }

        public FieldExceedDescriptionlengthException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
