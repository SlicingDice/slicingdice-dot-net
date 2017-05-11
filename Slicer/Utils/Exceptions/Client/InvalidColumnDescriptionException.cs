using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidColumnDescriptionException : SlicingDiceException
    {
        public InvalidColumnDescriptionException()
            : base() { }

        public InvalidColumnDescriptionException(string message)
            : base(message) { }

        public InvalidColumnDescriptionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
