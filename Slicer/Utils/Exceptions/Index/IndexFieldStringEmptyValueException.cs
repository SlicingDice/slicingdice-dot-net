using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldStringEmptyValueException : SlicingDiceException
    {
        public IndexFieldStringEmptyValueException()
            : base() { }

        public IndexFieldStringEmptyValueException(string message)
            : base(message) { }

        public IndexFieldStringEmptyValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
