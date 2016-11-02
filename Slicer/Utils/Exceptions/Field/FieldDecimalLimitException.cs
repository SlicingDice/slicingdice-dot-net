using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldDecimalLimitException : SlicingDiceException
    {
        public FieldDecimalLimitException()
            : base() { }

        public FieldDecimalLimitException(string message)
            : base(message) { }

        public FieldDecimalLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
