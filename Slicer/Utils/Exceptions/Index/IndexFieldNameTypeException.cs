using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldNameTypeException : SlicingDiceException
    {
        public IndexFieldNameTypeException()
            : base() { }

        public IndexFieldNameTypeException(string message)
            : base(message) { }

        public IndexFieldNameTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
