using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldNumericInvalidValueException : SlicingDiceException
    {
        public InsertFieldNumericInvalidValueException()
            : base() { }

        public InsertFieldNumericInvalidValueException(string message)
            : base(message) { }

        public InsertFieldNumericInvalidValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
