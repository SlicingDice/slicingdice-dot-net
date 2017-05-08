using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertInvalidDecimalPlacesException : SlicingDiceException
    {
        public InsertInvalidDecimalPlacesException()
            : base() { }

        public InsertInvalidDecimalPlacesException(string message)
            : base(message) { }

        public InsertInvalidDecimalPlacesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
