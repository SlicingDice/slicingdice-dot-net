using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnIntegerValuesException : SlicingDiceException
    {
        public ColumnIntegerValuesException()
            : base() { }

        public ColumnIntegerValuesException(string message)
            : base(message) { }

        public ColumnIntegerValuesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
