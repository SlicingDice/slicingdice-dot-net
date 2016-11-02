using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldTypeException : SlicingDiceException
    {
        public IndexFieldTypeException()
            : base() { }

        public IndexFieldTypeException(string message)
            : base(message) { }

        public IndexFieldTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
