using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryBadAggsFormationException : SlicingDiceException
    {
        public QueryBadAggsFormationException()
            : base() { }

        public QueryBadAggsFormationException(string message)
            : base(message) { }

        public QueryBadAggsFormationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
