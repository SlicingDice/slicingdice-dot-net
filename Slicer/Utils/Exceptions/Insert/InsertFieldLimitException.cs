using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnLimitException : SlicingDiceException
    {
        public InsertColumnLimitException()
            : base() { }

        public InsertColumnLimitException(string message)
            : base(message) { }

        public InsertColumnLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
