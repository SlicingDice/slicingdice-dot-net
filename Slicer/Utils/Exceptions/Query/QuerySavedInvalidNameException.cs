using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedInvalidNameException : SlicingDiceException
    {
        public QuerySavedInvalidNameException()
            : base() { }

        public QuerySavedInvalidNameException(string message)
            : base(message) { }

        public QuerySavedInvalidNameException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
