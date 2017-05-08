using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnExceededMaxApiNameLenghtException : SlicingDiceException
    {
        public ColumnExceededMaxApiNameLenghtException()
            : base() { }

        public ColumnExceededMaxApiNameLenghtException(string message)
            : base(message) { }

        public ColumnExceededMaxApiNameLenghtException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
