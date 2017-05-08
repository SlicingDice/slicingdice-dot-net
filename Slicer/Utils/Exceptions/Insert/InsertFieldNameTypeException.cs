using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnNameTypeException : SlicingDiceException
    {
        public InsertColumnNameTypeException()
            : base() { }

        public InsertColumnNameTypeException(string message)
            : base(message) { }

        public InsertColumnNameTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
