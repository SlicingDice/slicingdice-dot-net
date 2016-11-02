using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidFieldDescriptionException : SlicingDiceException
    {
        public InvalidFieldDescriptionException()
            : base() { }

        public InvalidFieldDescriptionException(string message)
            : base(message) { }

        public InvalidFieldDescriptionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
