﻿using Slicer.Utils.Exceptions;
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
            if (this.Query.ContainsKey("limit"))
            {
                var limitValue = (int) this.Query["limit"];
                if (limitValue > 100)
                {
                    throw new InvalidQueryException("The field 'limit' has a value max of 100.");
                }
            }
            if (this.Query.ContainsKey("fields"))
            {
                var fields = this.Query["fields"].ToObject<List<string>>();
                if (fields.Count > 10)
                {
                    throw new InvalidQueryException("The key 'fields' in data extraction result must have up to 10 fields.");
                }
            }
            return true;
        }
    }
}
