using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexFieldNotActiveException : SlicingDiceException
    {
        public IndexFieldNotActiveException()
            : base() { }

        public IndexFieldNotActiveException(string message)
            : base(message) { }

        public IndexFieldNotActiveException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
