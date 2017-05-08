using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnAlreadyExistsException : SlicingDiceException
    {
        public ColumnAlreadyExistsException()
            : base() { }

        public ColumnAlreadyExistsException(string message)
            : base(message) { }

        public ColumnAlreadyExistsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
