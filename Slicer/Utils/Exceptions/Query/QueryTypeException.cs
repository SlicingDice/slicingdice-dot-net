using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTypeException : SlicingDiceException
    {
        public QueryTypeException()
            : base() { }

        public QueryTypeException(string message)
            : base(message) { }

        public QueryTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
