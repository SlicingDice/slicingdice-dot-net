using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    // Validates field
    public class FieldValidator
    {
        dynamic Query;
        List<string> validTypesFields;
        public FieldValidator(dynamic query)
        {
            this.Query = query;
            this.validTypesFields = new List<string>()
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
                throw new InvalidFieldException("The field should have a name.");
            }
            else
            {
                var nameField = (string) Query["name"];
                if (nameField.Count() > 80)
                {
                    throw new InvalidFieldNameException("The field's name have a very big content. (Max: 80 chars)");
                }
            }
        }
        // Check if field description is valid
        private void ValidateDescription(Dictionary<string, dynamic> Query)
        {
            var description = (string)Query["description"];
            if (description.Count() > 300)
            {
                throw new InvalidFieldDescriptionException("The field's description have a very big content. (Max: 300chars)");
            }
        }
        // Check if field has a valid type
        private void ValidateFieldType(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("type"))
            {
                throw new InvalidFieldException("The field should have a type.");
            }
            var fieldType = (string)Query["type"];
            if (!validTypesFields.Contains(fieldType))
            {
                throw new InvalidFieldException("This field has a invalid type.");
            }
        }
        // Check if decimal field has a valid type
        private void ValidateDecimalType(Dictionary<string, dynamic> Query)
        {
            var decimalTypes = new List<string>()
            {
                "decimal", "decimal-time-series"
            };
            var typeField = (string) Query["type"];
            if (!decimalTypes.Contains(typeField))
            {
                throw new InvalidFieldException("This field only accepts 'decimal' or 'decimal-time-series' types");
            }
        }
        // Check if string field is valid
        private void CheckStringIntegrity(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("cardinality"))
            {
                throw new InvalidFieldException("The field with type string should have 'cardinality' key.");
            }
            var cardinalityTypes = new List<string>()
            {
                "high", "low"
            };
            var cardinality = (string) Query["cardinality"];
            if (!cardinalityTypes.Contains(cardinality))
            {
                throw new InvalidFieldException("The field 'cardinality' has invalid value.");
            }
        }
        // Check if enumerate field is valid
        private void ValidateEnumerateType(Dictionary<string, dynamic> Query)
        {
            if (!Query.ContainsKey("range"))
                throw new InvalidFieldException("The 'enumerate' type needs of the 'range' parameter.");
        }
        // Validate a field, returns true if the field is valid
        public bool Validator()
        {
            if (this.Query is List<dynamic>) {
                foreach (var q in this.Query) {
                    this.ValidateField(q);
                }
            } else {
                this.ValidateField(this.Query);
            }

            return true;
        }

        public void ValidateField(Dictionary<string, dynamic> Query) {
            this.ValidateName(Query);
            this.ValidateFieldType(Query);
            var typeField = (string) Query["type"];
            if (typeField == "string") this.CheckStringIntegrity(Query);
            if (typeField == "enumerated") this.ValidateEnumerateType(Query);
            if (Query.ContainsKey("description")) this.ValidateDescription(Query);
            if (Query.ContainsKey("decimal-place")) this.ValidateDecimalType(Query);
        }
    }
}
