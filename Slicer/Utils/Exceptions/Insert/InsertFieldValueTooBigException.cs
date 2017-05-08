﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InsertFieldValueTooBigException : SlicingDiceException
    {
        public InsertFieldValueTooBigException()
            : base() { }

        public InsertFieldValueTooBigException(string message)
            : base(message) { }

        public InsertFieldValueTooBigException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
