using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryIncompleteException : SlicingDiceException
    {
        public QueryIncompleteException()
            : base() { }

        public QueryIncompleteException(string message)
            : base(message) { }

        public QueryIncompleteException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
