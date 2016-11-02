using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class IndexEntityKeyTypeException : SlicingDiceException
    {
        public IndexEntityKeyTypeException()
            : base() { }

        public IndexEntityKeyTypeException(string message)
            : base(message) { }

        public IndexEntityKeyTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
