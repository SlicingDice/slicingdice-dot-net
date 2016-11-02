using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMissingNameParamException : SlicingDiceException
    {
        public QueryMissingNameParamException()
            : base() { }

        public QueryMissingNameParamException(string message)
            : base(message) { }

        public QueryMissingNameParamException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
