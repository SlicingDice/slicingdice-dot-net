using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnTypeException : SlicingDiceException
    {
        public InsertColumnTypeException()
            : base() { }

        public InsertColumnTypeException(string message)
            : base(message) { }

        public InsertColumnTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
