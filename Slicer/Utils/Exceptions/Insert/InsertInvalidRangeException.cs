using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertInvalidRangeException : SlicingDiceException
    {
        public InsertInvalidRangeException()
            : base() { }

        public InsertInvalidRangeException(string message)
            : base(message) { }

        public InsertInvalidRangeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
