using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QuerySavedNotExistsException : SlicingDiceException
    {
        public QuerySavedNotExistsException()
            : base() { }

        public QuerySavedNotExistsException(string message)
            : base(message) { }

        public QuerySavedNotExistsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
