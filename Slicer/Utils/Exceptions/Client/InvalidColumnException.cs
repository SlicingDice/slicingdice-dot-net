﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class InvalidColumnException : SlicingDiceException
    {
        public InvalidColumnException()
            : base() { }

        public InvalidColumnException(string message)
            : base(message) { }

        public InvalidColumnException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
