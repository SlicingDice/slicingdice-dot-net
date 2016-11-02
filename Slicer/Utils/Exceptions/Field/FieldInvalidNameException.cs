using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldInvalidNameException : SlicingDiceException
    {
        public FieldInvalidNameException()
            : base() { }

        public FieldInvalidNameException(string message)
            : base(message) { }

        public FieldInvalidNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
