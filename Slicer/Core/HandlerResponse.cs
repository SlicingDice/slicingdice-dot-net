using Newtonsoft.Json.Linq;
using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Core
{
    public class HandlerResponse
    {
        public Dictionary<string, dynamic> Result { get; set; }
        public HandlerResponse(Dictionary<string, dynamic> result)
        {
            this.Result = result;
        }
        // Raise proper exception according to the error code
        private void RaiseError(Dictionary<string, dynamic> error)
        {
            var errorCode = (int) error["code"];
			switch (errorCode)
            {
                case 2:
                    throw new DemoUnavailableException(error);
                case 1502:
					throw new RequestRateLimitException(error);
                case 1507:
					throw new RequestBodySizeExceededException(error);
                case 2012:
					throw new IndexEntitiesLimitException(error);
                case 2013:
					throw new IndexColumnsLimitException(error);
                default:
					throw new SlicingDiceException(error);
            }
        }
        // Handle successful requests
        public bool RequestSuccessful()
        {
            if (this.Result.ContainsKey("errors"))
            {
                JArray errorsObj = this.Result["errors"];
                List<Dictionary<string, dynamic>> errors = errorsObj.ToObject<List<Dictionary<string, dynamic>>>();
                Dictionary<string, dynamic> error = new Dictionary<string, dynamic>();
				this.RaiseError(errors[0]);
            }
            return true;
        }
    }
}
