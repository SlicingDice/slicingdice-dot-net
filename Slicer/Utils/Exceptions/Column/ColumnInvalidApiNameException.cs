using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnInvalidApiNameException : SlicingDiceException
    {
        public ColumnInvalidApiNameException()
            : base() { }

        public ColumnInvalidApiNameException(string message)
            : base(message) { }

        public ColumnInvalidApiNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
