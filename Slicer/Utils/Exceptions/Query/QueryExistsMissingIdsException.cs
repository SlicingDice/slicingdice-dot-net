using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryExistsMissingIdsException : SlicingDiceException
    {
        public QueryExistsMissingIdsException()
            : base() { }

        public QueryExistsMissingIdsException(string message)
            : base(message) { }

        public QueryExistsMissingIdsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
