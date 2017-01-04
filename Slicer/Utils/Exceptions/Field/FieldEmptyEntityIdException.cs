using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldEmptyEntityIdException : SlicingDiceException
    {
        public FieldEmptyEntityIdException()
            : base() { }

        public FieldEmptyEntityIdException(string message)
            : base(message) { }

        public FieldEmptyEntityIdException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
