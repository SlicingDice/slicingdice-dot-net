using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedInvalidQueryValueException : SlicingDiceException
    {
        public QuerySavedInvalidQueryValueException()
            : base() { }

        public QuerySavedInvalidQueryValueException(string message)
            : base(message) { }

        public QuerySavedInvalidQueryValueException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
