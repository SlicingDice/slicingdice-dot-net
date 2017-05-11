using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    // Validates top values queries
    public class QueryTopValuesValidator
    {
        Dictionary<string, dynamic> Query;
        public QueryTopValuesValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
        }
        // Check if top values query exceeds query limit
        private bool ExceedsQueriesLimit(){
            if (this.Query.Count > 5)
            {
                throw new MaxLimitException("Validator query has a limit of 5 queries by request.");
            }
            return false;
        }
        // Validate if top values query exceeds columns limit
        private bool ExceedsColumnsLimit()
        {
            foreach (KeyValuePair<string, dynamic> data in this.Query)
            {
                var v = data.Value;
                if (v.Count > 6)
                {
                    throw new MaxLimitException(string.Format("The query '{0}' exceeds the limit of columns per query in request", data.Key));
                }
            }
            return false;
        }
        // Validate if top values query exceeds contains limit
        private bool ExceedsValuesContainsLimit()
        {
            foreach (KeyValuePair<string, dynamic> data in this.Query)
            {
                var dictionaryValue = data.Value;

                if (!(dictionaryValue is Dictionary<string, dynamic>)) {
                    dictionaryValue = data.Value.ToObject<Dictionary<string, dynamic>>();
                }

                if (dictionaryValue.ContainsKey("contains"))
                {
                    var valuesContains = dictionaryValue["contains"];
                    if (valuesContains.Count > 5)
                    {
                        throw new MaxLimitException(string.Format("The query '{0}' exceeds the limit of contains per query in request", data.Key));
                    }
                }
            }
            return false;
        }
        // Validates top values query, if the query is valid returns true, otherwise return false
        public bool Validator()
        {
            if (!this.ExceedsQueriesLimit() && !this.ExceedsColumnsLimit() && !this.ExceedsValuesContainsLimit())
            {
                return true;
            }
            return false;
        }
    }
}
