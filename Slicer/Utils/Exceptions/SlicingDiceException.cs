using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Exceptions
{
    public class SlicingDiceException: Exception
    {
		public int code;
		public string message;
		public object moreInfo;

        public SlicingDiceException()
			: base() { }

		public SlicingDiceException(string message)
			: base(message) {
			this.message = message;
		}

		public SlicingDiceException(Dictionary<string, dynamic> data) 
			: base(){
			if (data.ContainsKey("code")) {
				this.code = (int) data["code"];
			}
			if (data.ContainsKey ("message")) {
				this.message = (string) data["message"];
			}
			if (data.ContainsKey ("more-info")) {
				this.moreInfo = data["more-info"];
			}
		}

        public SlicingDiceException(string format, params object[] args)
            : base(string.Format(format, args)) { }

		public override String Message {
			get {  
				return String.Format("code={0}, message={1}, more_info='{2}'", 
					this.code, 
					this.message,
					this.moreInfo
				);
			}
		}
    }
}
