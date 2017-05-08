using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldStringEmptyValueException : SlicingDiceException
    {
        public InsertFieldStringEmptyValueException()
            : base() { }

        public InsertFieldStringEmptyValueException(string message)
            : base(message) { }

        public InsertFieldStringEmptyValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
