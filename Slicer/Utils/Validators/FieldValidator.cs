using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    // Validates field
    public class ColumnValidator
    {
        dynamic Query;
        List<string> validTypesColumns;
        public ColumnValidator(dynamic query)
        {
            this.Query = query;
            this.validTypesColumns = new List<string>()
            {
                "unique-id", "boolean", "string", "integer", "decimal",
                "enumerated", "date", "integer-time-series",
                "decimal-time-series", "string-time-series"
            };
        }
        // Check if field name is valid
        private void ValidateName(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("name"))
            {
                throw new InvalidColumnException("The field should have a name.");
            }
            else
            {
                var nameColumn = (string) Query["name"];
                if (nameColumn.Count() > 80)
                {
                    throw new InvalidColumnNameException("The field's name have a very big content. (Max: 80 chars)");
                }
            }
        }
        // Check if field description is valid
        private void ValidateDescription(Dictionary<string, dynamic> Query)
        {
            var description = (string)Query["description"];
            if (description.Count() > 300)
            {
                throw new InvalidColumnDescriptionException("The field's description have a very big content. (Max: 300chars)");
            }
        }
        // Check if field has a valid type
        private void ValidateColumnType(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("type"))
            {
                throw new InvalidColumnException("The field should have a type.");
            }
            var fieldType = (string)Query["type"];
            if (!validTypesColumns.Contains(fieldType))
            {
                throw new InvalidColumnException("This field has a invalid type.");
            }
        }
        // Check if decimal field has a valid type
        private void ValidateDecimalType(Dictionary<string, dynamic> Query)
        {
            var decimalTypes = new List<string>()
            {
                "decimal", "decimal-time-series"
            };
            var typeColumn = (string) Query["type"];
            if (!decimalTypes.Contains(typeColumn))
            {
                throw new InvalidColumnException("This field only accepts 'decimal' or 'decimal-time-series' types");
            }
        }
        // Check if string field is valid
        private void CheckStringIntegrity(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("cardinality"))
            {
                throw new InvalidColumnException("The field with type string should have 'cardinality' key.");
            }
            var cardinalityTypes = new List<string>()
            {
                "high", "low"
            };
            var cardinality = (string) Query["cardinality"];
            if (!cardinalityTypes.Contains(cardinality))
            {
                throw new InvalidColumnException("The field 'cardinality' has invalid value.");
            }
        }
        // Check if enumerate field is valid
        private void ValidateEnumerateType(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("range"))
                throw new InvalidColumnException("The 'enumerate' type needs of the 'range' parameter.");
        }
        // Validate a field, returns true if the field is valid
        public bool Validator()
        {
            if (this.Query is List<dynamic>) {
                foreach (var q in this.Query) {
                    this.ValidateColumn(q);
                }
            } else {
                this.ValidateColumn(this.Query);
            }

            return true;
        }

        public void ValidateColumn(Dictionary<string, dynamic> Query) {
            this.ValidateName(Query);
            this.ValidateColumnType(Query);
            var typeColumn = (string) Query["type"];
            if (typeColumn == "string") this.CheckStringIntegrity(Query);
            if (typeColumn == "enumerated") this.ValidateEnumerateType(Query);
            if (Query.ContainsKey("description")) this.ValidateDescription(Query);
            if (Query.ContainsKey("decimal-place")) this.ValidateDecimalType(Query);
        }
    }
}
