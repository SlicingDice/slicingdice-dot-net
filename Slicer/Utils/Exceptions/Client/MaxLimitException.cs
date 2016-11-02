using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class MaxLimitException : SlicingDiceException
    {
        public MaxLimitException()
            : base() { }

        public MaxLimitException(string message)
            : base(message) { }

        public MaxLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
