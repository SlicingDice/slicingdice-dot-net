using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnNumericInvalidValueException : SlicingDiceException
    {
        public InsertColumnNumericInvalidValueException()
            : base() { }

        public InsertColumnNumericInvalidValueException(string message)
            : base(message) { }

        public InsertColumnNumericInvalidValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
