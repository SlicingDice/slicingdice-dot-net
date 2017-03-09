using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    // Validates saved query
    public class SavedQueryValidator
    {
        Dictionary<string, dynamic> Query;
        List<string> _listQueryTypes = new List<string>()
        {
            "count/entity", "count/event", "count/entity/total",
            "aggregation", "top_values"
        };
        public SavedQueryValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
        }
        // Check if saved query has a valid type
        private bool HasValidType()
        {
            var queryType = (string) this.Query["type"];
            if (!this._listQueryTypes.Contains(queryType)) throw new InvalidQueryTypeException("This dictionary doesn't have a valid type.");
            return true;
        }
        // Validates saved query, returns true if is valid
        public bool Validator()
        {
            return this.HasValidType();
        }
    }
}
