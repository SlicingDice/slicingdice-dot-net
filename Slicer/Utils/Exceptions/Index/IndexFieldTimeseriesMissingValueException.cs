using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldTimeseriesMissingValueException : SlicingDiceException
    {
        public IndexFieldTimeseriesMissingValueException()
            : base() { }

        public IndexFieldTimeseriesMissingValueException(string message)
            : base(message) { }

        public IndexFieldTimeseriesMissingValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
