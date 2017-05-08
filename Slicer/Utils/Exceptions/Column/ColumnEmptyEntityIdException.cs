using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnEmptyEntityIdException : SlicingDiceException
    {
        public ColumnEmptyEntityIdException()
            : base() { }

        public ColumnEmptyEntityIdException(string message)
            : base(message) { }

        public ColumnEmptyEntityIdException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
