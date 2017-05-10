using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    class IndexEntitiesLimitException : SlicingDiceException
    {
        public IndexEntitiesLimitException()
            : base() { }

        public IndexEntitiesLimitException(string message)
			: base(message) { }

		public IndexEntitiesLimitException(Dictionary<string, dynamic> data)
			: base(data) { }

        public IndexEntitiesLimitException(string format, params object[] args)
            : base(string.Format(format, args)) { }

    }
}
