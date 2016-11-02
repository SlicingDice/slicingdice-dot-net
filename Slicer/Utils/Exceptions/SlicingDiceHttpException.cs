using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class SlicingDiceHttpException : SlicingDiceException
    {
        public SlicingDiceHttpException()
            : base() { }

        public SlicingDiceHttpException(string message)
            : base(message) { }

        public SlicingDiceHttpException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
