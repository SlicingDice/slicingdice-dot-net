using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldLimitException : SlicingDiceException
    {
        public InsertFieldLimitException()
            : base() { }

        public InsertFieldLimitException(string message)
            : base(message) { }

        public InsertFieldLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
