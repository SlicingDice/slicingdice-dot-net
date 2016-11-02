using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedAlreadyExistsException : SlicingDiceException
    {
        public QuerySavedAlreadyExistsException()
            : base() { }

        public QuerySavedAlreadyExistsException(string message)
            : base(message) { }

        public QuerySavedAlreadyExistsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
