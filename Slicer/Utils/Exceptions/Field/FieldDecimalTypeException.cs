using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldDecimalTypeException : SlicingDiceException
    {
        public FieldDecimalTypeException()
            : base() { }

        public FieldDecimalTypeException(string message)
            : base(message) { }

        public FieldDecimalTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
