using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertDateFormatException : SlicingDiceException
    {
        public InsertDateFormatException()
            : base() { }

        public InsertDateFormatException(string message)
            : base(message) { }

        public InsertDateFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
