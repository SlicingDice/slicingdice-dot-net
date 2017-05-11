using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class DemoUnavailableException : SlicingDiceException
    {
        public DemoUnavailableException()
            : base() { }

        public DemoUnavailableException(string message)
			: base(message) { }
		
		public DemoUnavailableException(Dictionary<string, dynamic> data)
			: base(data) { }

        public DemoUnavailableException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
