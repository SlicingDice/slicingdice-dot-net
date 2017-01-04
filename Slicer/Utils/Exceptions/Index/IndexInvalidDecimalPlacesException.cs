using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexInvalidDecimalPlacesException : SlicingDiceException
    {
        public IndexInvalidDecimalPlacesException()
            : base() { }

        public IndexInvalidDecimalPlacesException(string message)
            : base(message) { }

        public IndexInvalidDecimalPlacesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
