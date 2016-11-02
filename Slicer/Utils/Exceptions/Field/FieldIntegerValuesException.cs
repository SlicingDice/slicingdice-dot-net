using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldIntegerValuesException : SlicingDiceException
    {
        public FieldIntegerValuesException()
            : base() { }

        public FieldIntegerValuesException(string message)
            : base(message) { }

        public FieldIntegerValuesException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
