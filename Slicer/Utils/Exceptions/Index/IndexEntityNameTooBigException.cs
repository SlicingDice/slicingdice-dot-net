using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexEntityNameTooBigException : SlicingDiceException
    {
        public IndexEntityNameTooBigException()
            : base() { }

        public IndexEntityNameTooBigException(string message)
            : base(message) { }

        public IndexEntityNameTooBigException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
