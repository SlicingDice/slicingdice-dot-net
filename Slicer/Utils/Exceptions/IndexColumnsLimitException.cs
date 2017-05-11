using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class IndexColumnsLimitException : SlicingDiceException
    {
        public IndexColumnsLimitException()
            : base() { }

        public IndexColumnsLimitException(string message)
			: base(message) { }

		public IndexColumnsLimitException(Dictionary<string, dynamic> data)
			: base(data) { }

        public IndexColumnsLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
