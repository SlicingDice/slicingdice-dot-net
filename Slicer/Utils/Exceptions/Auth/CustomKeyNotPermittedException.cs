﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class CustomKeyNotPermittedException : SlicingDiceException
    {
        public CustomKeyNotPermittedException()
            : base() { }

        public CustomKeyNotPermittedException(string message)
            : base(message) { }

        public CustomKeyNotPermittedException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
