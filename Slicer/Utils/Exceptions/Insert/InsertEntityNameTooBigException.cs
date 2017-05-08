using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertEntityNameTooBigException : SlicingDiceException
    {
        public InsertEntityNameTooBigException()
            : base() { }

        public InsertEntityNameTooBigException(string message)
            : base(message) { }

        public InsertEntityNameTooBigException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
