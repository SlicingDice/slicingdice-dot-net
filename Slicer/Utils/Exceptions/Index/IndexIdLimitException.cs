using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexIdLimitException : SlicingDiceException
    {
        public IndexIdLimitException()
            : base() { }

        public IndexIdLimitException(string message)
            : base(message) { }

        public IndexIdLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
