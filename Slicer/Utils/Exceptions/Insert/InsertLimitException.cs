using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertLimitException : SlicingDiceException
    {
        public InsertLimitException()
            : base() { }

        public InsertLimitException(string message)
            : base(message) { }

        public InsertLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
