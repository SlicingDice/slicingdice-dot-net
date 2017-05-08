using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertColumnTimeseriesMissingValueException : SlicingDiceException
    {
        public InsertColumnTimeseriesMissingValueException()
            : base() { }

        public InsertColumnTimeseriesMissingValueException(string message)
            : base(message) { }

        public InsertColumnTimeseriesMissingValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
