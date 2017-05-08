using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnLimitException : SlicingDiceException
    {
        public ColumnLimitException()
            : base() { }

        public ColumnLimitException(string message)
            : base(message) { }

        public ColumnLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
