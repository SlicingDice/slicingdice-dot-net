using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldTypeException : SlicingDiceException
    {
        public InsertFieldTypeException()
            : base() { }

        public InsertFieldTypeException(string message)
            : base(message) { }

        public InsertFieldTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
