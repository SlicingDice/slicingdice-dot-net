using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldLimitException : SlicingDiceException
    {
        public IndexFieldLimitException()
            : base() { }

        public IndexFieldLimitException(string message)
            : base(message) { }

        public IndexFieldLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
