using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertIdLimitException : SlicingDiceException
    {
        public InsertIdLimitException()
            : base() { }

        public InsertIdLimitException(string message)
            : base(message) { }

        public InsertIdLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
