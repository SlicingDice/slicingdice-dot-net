using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnInvalidCardinalityException : SlicingDiceException
    {
        public ColumnInvalidCardinalityException()
            : base() { }

        public ColumnInvalidCardinalityException(string message)
            : base(message) { }

        public ColumnInvalidCardinalityException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
