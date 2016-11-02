using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidQueryTypeException : SlicingDiceException
    {
        public InvalidQueryTypeException()
            : base() { }

        public InvalidQueryTypeException(string message)
            : base(message) { }

        public InvalidQueryTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
