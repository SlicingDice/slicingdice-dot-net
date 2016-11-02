using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidFormatException : SlicingDiceException
    {
        public QueryInvalidFormatException()
            : base() { }

        public QueryInvalidFormatException(string message)
            : base(message) { }

        public QueryInvalidFormatException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
