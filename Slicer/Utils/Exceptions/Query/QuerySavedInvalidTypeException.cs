using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedInvalidTypeException : SlicingDiceException
    {
        public QuerySavedInvalidTypeException()
            : base() { }

        public QuerySavedInvalidTypeException(string message)
            : base(message) { }

        public QuerySavedInvalidTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
