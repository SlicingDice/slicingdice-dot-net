﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class FieldTimeSeriesLimitException : SlicingDiceException
    {
        public FieldTimeSeriesLimitException()
            : base() { }

        public FieldTimeSeriesLimitException(string message)
            : base(message) { }

        public FieldTimeSeriesLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
