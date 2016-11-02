﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class RequestRateLimitException : SlicingDiceException
    {
        public RequestRateLimitException()
            : base() { }

        public RequestRateLimitException(string message)
            : base(message) { }

        public RequestRateLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
