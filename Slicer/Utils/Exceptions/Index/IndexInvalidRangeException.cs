using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexInvalidRangeException : SlicingDiceException
    {
        public IndexInvalidRangeException()
            : base() { }

        public IndexInvalidRangeException(string message)
            : base(message) { }

        public IndexInvalidRangeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
