using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class ColumnInvalidNameException : SlicingDiceException
    {
        public ColumnInvalidNameException()
            : base() { }

        public ColumnInvalidNameException(string message)
            : base(message) { }

        public ColumnInvalidNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
