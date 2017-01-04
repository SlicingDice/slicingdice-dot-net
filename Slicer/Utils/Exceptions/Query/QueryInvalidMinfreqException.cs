using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryInvalidMinfreqException : SlicingDiceException
    {
        public QueryInvalidMinfreqException()
            : base() { }

        public QueryInvalidMinfreqException(string message)
            : base(message) { }

        public QueryInvalidMinfreqException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
