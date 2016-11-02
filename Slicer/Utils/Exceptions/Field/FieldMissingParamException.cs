using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldMissingParamException : SlicingDiceException
    {
        public FieldMissingParamException()
            : base() { }

        public FieldMissingParamException(string message)
            : base(message) { }

        public FieldMissingParamException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
