using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexLimitException : SlicingDiceException
    {
        public IndexLimitException()
            : base() { }

        public IndexLimitException(string message)
            : base(message) { }

        public IndexLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
