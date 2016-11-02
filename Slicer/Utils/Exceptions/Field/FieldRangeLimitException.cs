using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldRangeLimitException : SlicingDiceException
    {
        public FieldRangeLimitException()
            : base() { }

        public FieldRangeLimitException(string message)
            : base(message) { }

        public FieldRangeLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
