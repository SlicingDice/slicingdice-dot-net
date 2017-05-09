using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnTimeSeriesMissingValueException : SlicingDiceException
    {
        public InsertColumnTimeSeriesMissingValueException()
            : base() { }

        public InsertColumnTimeSeriesMissingValueException(string message)
            : base(message) { }

        public InsertColumnTimeSeriesMissingValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
