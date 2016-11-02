using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class SlicingDiceException: Exception
    {
        public SlicingDiceException()
            : base() { }

        public SlicingDiceException(string message)
            : base(message) { }

        public SlicingDiceException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
