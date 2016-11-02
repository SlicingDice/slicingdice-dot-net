using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldStorageValueException : SlicingDiceException
    {
        public FieldStorageValueException()
            : base() { }

        public FieldStorageValueException(string message)
            : base(message) { }

        public FieldStorageValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
