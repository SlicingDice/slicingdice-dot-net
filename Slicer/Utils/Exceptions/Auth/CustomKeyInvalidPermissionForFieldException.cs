using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyInvalidPermissionForFieldException : SlicingDiceException
    {
        public CustomKeyInvalidPermissionForFieldException()
            : base() { }

        public CustomKeyInvalidPermissionForFieldException(string message)
            : base(message) { }

        public CustomKeyInvalidPermissionForFieldException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
