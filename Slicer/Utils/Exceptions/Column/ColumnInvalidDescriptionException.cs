using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnInvalidDescriptionException : SlicingDiceException
    {
        public ColumnInvalidDescriptionException()
            : base() { }

        public ColumnInvalidDescriptionException(string message)
            : base(message) { }

        public ColumnInvalidDescriptionException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
