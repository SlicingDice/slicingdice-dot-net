using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnExceededDescriptionlengthException : SlicingDiceException
    {
        public ColumnExceededDescriptionlengthException()
            : base() { }

        public ColumnExceededDescriptionlengthException(string message)
            : base(message) { }

        public ColumnExceededDescriptionlengthException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
