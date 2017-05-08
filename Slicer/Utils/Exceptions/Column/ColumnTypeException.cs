using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnTypeException : SlicingDiceException
    {
        public ColumnTypeException()
            : base() { }

        public ColumnTypeException(string message)
            : base(message) { }

        public ColumnTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
