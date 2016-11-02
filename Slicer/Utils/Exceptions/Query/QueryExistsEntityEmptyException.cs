using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryExistsEntityEmptyException : SlicingDiceException
    {
        public QueryExistsEntityEmptyException()
            : base() { }

        public QueryExistsEntityEmptyException(string message)
            : base(message) { }

        public QueryExistsEntityEmptyException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
