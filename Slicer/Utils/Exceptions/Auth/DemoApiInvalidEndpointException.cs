using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class DemoApiInvalidEndpointException : SlicingDiceException
    {
        public DemoApiInvalidEndpointException()
            : base() { }

        public DemoApiInvalidEndpointException(string message)
            : base(message) { }

        public DemoApiInvalidEndpointException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
