using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnRangeLimitException : SlicingDiceException
    {
        public ColumnRangeLimitException()
            : base() { }

        public ColumnRangeLimitException(string message)
            : base(message) { }

        public ColumnRangeLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
