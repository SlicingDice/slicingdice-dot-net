using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    public class QueryTopValuesValidator
    {
        Dictionary<string, dynamic> Query;
        public QueryTopValuesValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
        }
        private bool ExceedsQueriesLimit(){
            if (this.Query.Count > 5)
            {
                throw new MaxLimitException("Validator query has a limit of 5 queries by request.");
            }
            return false;
        }

        private bool ExceedsFieldsLimit()
        {
            foreach (KeyValuePair<string, dynamic> data in this.Query)
            {
                var v = data.Value.ToObject<Dictionary<string, dynamic>>();
                if (v.Count > 6)
                {
                    throw new MaxLimitException(string.Format("The query '{0}' exceeds the limit of fields per query in request", data.Key));
                }
            }
            return false;
        }
        private bool ExceedsValuesContainsLimit()
        {
            foreach (KeyValuePair<string, dynamic> data in this.Query)
            {
                var v = data.Value.ToObject<Dictionary<string, dynamic>>();
                if (v.ContainsKey("contains"))
                {
                    var valuesContains = v["contains"].ToObject<List<string>>();
                    if (valuesContains.Count > 5)
                    {
                        throw new MaxLimitException(string.Format("The query '{0}' exceeds the limit of contains per query in request", data.Key));
                    }
                }
            }
            return false;
        }
        public bool Validator()
        {
            if (!this.ExceedsQueriesLimit() && !this.ExceedsFieldsLimit() && !this.ExceedsValuesContainsLimit())
            {
                return true;
            }
            return false;
        }
    }
}
