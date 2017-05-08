using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnStorageValueException : SlicingDiceException
    {
        public ColumnStorageValueException()
            : base() { }

        public ColumnStorageValueException(string message)
            : base(message) { }

        public ColumnStorageValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
