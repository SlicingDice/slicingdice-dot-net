using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
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
        private bool HasValidType()
        {
            var queryType = (string) this.Query["type"];
            if (!this._listQueryTypes.Contains(queryType)) throw new InvalidQueryTypeException("This dictionary don't have query type valid.");
            return true;
        }
        public bool Validator()
        {
            return this.HasValidType();
        }
    }
}
