using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    // Validates data extraction queries
    public class DataExtractionQueryValidator
    {
        Dictionary<string, dynamic> Query;
        public DataExtractionQueryValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
        }

        // Validate data extraction query, if the query is valid will return true
        public bool Validator()
        {
            if (this.Query.ContainsKey("columns"))
            {
                var columns = this.Query["columns"];
                if (columns.Count > 10)
                {
                    throw new InvalidQueryException("The key 'columns' in data extraction result must have up to 10 columns.");
                }
            }
            return true;
        }
    }
}
