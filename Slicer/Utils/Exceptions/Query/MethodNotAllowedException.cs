using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class MethodNotAllowedException : SlicingDiceException
    {
        public MethodNotAllowedException()
            : base() { }

        public MethodNotAllowedException(string message)
            : base(message) { }

        public MethodNotAllowedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
