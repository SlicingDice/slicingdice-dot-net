using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexEntityValueTypeException : SlicingDiceException
    {
        public IndexEntityValueTypeException()
            : base() { }

        public IndexEntityValueTypeException(string message)
            : base(message) { }

        public IndexEntityValueTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
