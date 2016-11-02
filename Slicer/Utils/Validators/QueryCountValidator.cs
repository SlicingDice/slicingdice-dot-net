using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    public class QueryCountValidator
    {
        Dictionary<string, dynamic> Query;
        public QueryCountValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
        }
        public bool Validator()
        {
            if (this.Query.Count > 10)
            {
                throw new MaxLimitException("The query count entity has a limit of 10 queries by request.");
            }
            return true;
        }
    }
}
