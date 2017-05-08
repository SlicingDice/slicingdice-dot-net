using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyInvalidPermissionForColumnException : SlicingDiceException
    {
        public CustomKeyInvalidPermissionForColumnException()
            : base() { }

        public CustomKeyInvalidPermissionForColumnException(string message)
            : base(message) { }

        public CustomKeyInvalidPermissionForColumnException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
