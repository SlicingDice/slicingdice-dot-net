using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnExceedDescriptionlengthException : SlicingDiceException
    {
        public ColumnExceedDescriptionlengthException()
            : base() { }

        public ColumnExceedDescriptionlengthException(string message)
            : base(message) { }

        public ColumnExceedDescriptionlengthException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
