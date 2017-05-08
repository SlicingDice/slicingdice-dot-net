using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertEntityValueTypeException : SlicingDiceException
    {
        public InsertEntityValueTypeException()
            : base() { }

        public InsertEntityValueTypeException(string message)
            : base(message) { }

        public InsertEntityValueTypeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
