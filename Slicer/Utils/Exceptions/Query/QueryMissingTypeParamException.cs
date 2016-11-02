﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class QueryMissingTypeParamException : SlicingDiceException
    {
        public QueryMissingTypeParamException()
            : base() { }

        public QueryMissingTypeParamException(string message)
            : base(message) { }

        public QueryMissingTypeParamException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
