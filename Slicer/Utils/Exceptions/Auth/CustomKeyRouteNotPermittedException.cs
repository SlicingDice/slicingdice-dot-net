using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyRouteNotPermittedException : SlicingDiceException
    {
        public CustomKeyRouteNotPermittedException()
            : base() { }

        public CustomKeyRouteNotPermittedException(string message)
            : base(message) { }

        public CustomKeyRouteNotPermittedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
