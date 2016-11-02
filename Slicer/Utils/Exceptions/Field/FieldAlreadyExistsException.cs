using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldAlreadyExistsException : SlicingDiceException
    {
        public FieldAlreadyExistsException()
            : base() { }

        public FieldAlreadyExistsException(string message)
            : base(message) { }

        public FieldAlreadyExistsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
