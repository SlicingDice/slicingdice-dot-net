using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidColumnNameException : SlicingDiceException
    {
        public InvalidColumnNameException()
            : base() { }

        public InvalidColumnNameException(string message)
            : base(message) { }

        public InvalidColumnNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
