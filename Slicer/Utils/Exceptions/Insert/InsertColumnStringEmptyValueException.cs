using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnStringEmptyValueException : SlicingDiceException
    {
        public InsertColumnStringEmptyValueException()
            : base() { }

        public InsertColumnStringEmptyValueException(string message)
            : base(message) { }

        public InsertColumnStringEmptyValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
