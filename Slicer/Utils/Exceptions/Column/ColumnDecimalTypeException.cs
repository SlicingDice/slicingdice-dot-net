using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnDecimalTypeException : SlicingDiceException
    {
        public ColumnDecimalTypeException()
            : base() { }

        public ColumnDecimalTypeException(string message)
            : base(message) { }

        public ColumnDecimalTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
