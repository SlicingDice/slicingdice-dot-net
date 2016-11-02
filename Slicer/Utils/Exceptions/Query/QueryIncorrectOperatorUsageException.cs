using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryIncorrectOperatorUsageException : SlicingDiceException
    {
        public QueryIncorrectOperatorUsageException()
            : base() { }

        public QueryIncorrectOperatorUsageException(string message)
            : base(message) { }

        public QueryIncorrectOperatorUsageException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
