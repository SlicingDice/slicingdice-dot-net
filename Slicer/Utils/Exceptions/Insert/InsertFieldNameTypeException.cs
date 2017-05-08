using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldNameTypeException : SlicingDiceException
    {
        public InsertFieldNameTypeException()
            : base() { }

        public InsertFieldNameTypeException(string message)
            : base(message) { }

        public InsertFieldNameTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
