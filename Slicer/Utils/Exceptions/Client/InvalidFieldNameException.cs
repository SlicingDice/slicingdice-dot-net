using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidFieldNameException : SlicingDiceException
    {
        public InvalidFieldNameException()
            : base() { }

        public InvalidFieldNameException(string message)
            : base(message) { }

        public InvalidFieldNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
