using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidQueryException : SlicingDiceException
    {
        public InvalidQueryException()
            : base() { }

        public InvalidQueryException(string message)
            : base(message) { }

        public InvalidQueryException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
