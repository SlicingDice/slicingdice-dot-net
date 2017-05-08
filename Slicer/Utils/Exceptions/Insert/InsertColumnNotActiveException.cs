using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnNotActiveException : SlicingDiceException
    {
        public InsertColumnNotActiveException()
            : base() { }

        public InsertColumnNotActiveException(string message)
            : base(message) { }

        public InsertColumnNotActiveException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
