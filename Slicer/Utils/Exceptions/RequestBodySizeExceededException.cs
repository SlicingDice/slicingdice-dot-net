using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class RequestBodySizeExceededException : SlicingDiceException
    {
        public RequestBodySizeExceededException()
            : base() { }

        public RequestBodySizeExceededException(string message)
			: base(message) { }

		public RequestBodySizeExceededException(Dictionary<string, dynamic> data)
			: base(data) { }

        public RequestBodySizeExceededException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
