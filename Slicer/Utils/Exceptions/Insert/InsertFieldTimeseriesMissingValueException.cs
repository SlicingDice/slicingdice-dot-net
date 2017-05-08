using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldTimeseriesMissingValueException : SlicingDiceException
    {
        public InsertFieldTimeseriesMissingValueException()
            : base() { }

        public InsertFieldTimeseriesMissingValueException(string message)
            : base(message) { }

        public InsertFieldTimeseriesMissingValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
