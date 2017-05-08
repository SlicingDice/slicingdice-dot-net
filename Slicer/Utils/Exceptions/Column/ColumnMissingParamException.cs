using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnMissingParamException : SlicingDiceException
    {
        public ColumnMissingParamException()
            : base() { }

        public ColumnMissingParamException(string message)
            : base(message) { }

        public ColumnMissingParamException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
