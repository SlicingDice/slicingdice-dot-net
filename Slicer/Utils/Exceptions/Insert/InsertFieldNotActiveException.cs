using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldNotActiveException : SlicingDiceException
    {
        public InsertFieldNotActiveException()
            : base() { }

        public InsertFieldNotActiveException(string message)
            : base(message) { }

        public InsertFieldNotActiveException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
