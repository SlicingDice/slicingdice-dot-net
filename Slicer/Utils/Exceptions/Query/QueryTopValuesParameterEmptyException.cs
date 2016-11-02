using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryTopValuesParameterEmptyException : SlicingDiceException
    {
        public QueryTopValuesParameterEmptyException()
            : base() { }

        public QueryTopValuesParameterEmptyException(string message)
            : base(message) { }

        public QueryTopValuesParameterEmptyException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
