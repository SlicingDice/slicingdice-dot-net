using Slicer.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.Utils.Validators
{
    public class FieldValidator
    {
        Dictionary<string, dynamic> Query;
        List<string> validTypesFields;
        public FieldValidator(Dictionary<string, dynamic> query)
        {
            this.Query = query;
            this.validTypesFields = new List<string>()
            {
                "unique-id", "boolean", "string", "integer", "decimal",
                "enumerated", "date", "integer-time-series",
                "decimal-time-series", "string-time-series"
            };
        }
        private void ValidateName()
        {
            if (!this.Query.ContainsKey("name"))
            {
                throw new InvalidFieldException("The field should have a name.");
            }
            else
            {
                var nameField = (string) this.Query["name"];
                if (nameField.Count() > 80)
                {
                    throw new InvalidFieldNameException("The field's name have a very big name.(Max: 80 chars)");
                }
            }
        }
        private void ValidateDescription()
        {
            var description = (string)this.Query["description"];
            if (description.Count() > 300)
            {
                throw new InvalidFieldDescriptionException("The field's description have a very big name.(Max: 300chars)");
            }
        }
        private void ValidateFieldType()
        {
            if (!this.Query.ContainsKey("type"))
            {
                throw new InvalidFieldException("The field should have a type.");
            }
            var fieldType = (string)this.Query["type"];
            if (!this.validTypesFields.Contains(fieldType))
            {
                throw new InvalidFieldException("This field have a invalid type.");
            }
        }
        private void ValidateDecimalPlaces()
        {
            var decimalTypes = new List<string>()
            {
                "decimal", "decimal-time-series"
            };
            var typeField = (string) this.Query["type"];
            if (!decimalTypes.Contains(typeField))
            {
                throw new InvalidFieldException("This field is only accepted on type 'decimal' or 'decimal-time-series'");
            }
        }
        private void CheckStringIntegrity()
        {
            if (!this.Query.ContainsKey("cardinality"))
            {
                throw new InvalidFieldException("The field with type string should have 'cardinality' key.");
            }
            var cardinalityTypes = new List<string>()
            {
                "high", "low"
            };
            var cardinality = (string) this.Query["cardinality"];
            if (!cardinalityTypes.Contains(cardinality))
            {
                throw new InvalidFieldException("The field 'cardinality' has invalid value.");
            }
        }
        private void ValidateEnumerateType()
        {
            if (!this.Query.ContainsKey("range"))
                throw new InvalidFieldException("The 'enumerate' type needs of the 'range' parameter.");
        }
        public bool Validator()
        {
            this.ValidateName();
            this.ValidateFieldType();
            var typeField = (string)this.Query["type"];
            if (typeField == "string") this.CheckStringIntegrity();
            if (typeField == "enumerated") this.ValidateEnumerateType();
            if (this.Query.ContainsKey("description")) this.ValidateDescription();
            if (this.Query.ContainsKey("decimal-place")) this.ValidateDecimalPlaces();
            return true;
        }
    }
}
