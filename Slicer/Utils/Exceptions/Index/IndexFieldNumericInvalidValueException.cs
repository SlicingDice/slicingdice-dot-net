using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldNumericInvalidValueException : SlicingDiceException
    {
        public IndexFieldNumericInvalidValueException()
            : base() { }

        public IndexFieldNumericInvalidValueException(string message)
            : base(message) { }

        public IndexFieldNumericInvalidValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
