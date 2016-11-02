using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexDateFormatException : SlicingDiceException
    {
        public IndexDateFormatException()
            : base() { }

        public IndexDateFormatException(string message)
            : base(message) { }

        public IndexDateFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
