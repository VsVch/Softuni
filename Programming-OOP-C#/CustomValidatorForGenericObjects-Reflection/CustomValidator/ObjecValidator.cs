using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CustomValidator
{
    public class ObjecValidator
    {
        private static IDictionary<Type, List<PropertyAttributes>> Cache =
            new Dictionary<Type, List<PropertyAttributes>>();


        public ValidationResult Validator(object obj)
        {
            if (obj == null)
            {
                ValidationResult result = new ValidationResult();

                result.AddError("Object", "Object is null.");

                return result;
            }

            var validationResult = new ValidationResult();

            ValidateValidatable(obj, validationResult);
            ValidateProperties(obj, validationResult);

            return validationResult;
        }

        private void ValidateValidatable
           (object obj, ValidationResult validationResult)
        {
            if (!(obj is IValidatable validatable))
            {
                return;
            }

            var additionalErrors = validatable.Validate();

            foreach (var additionalError in additionalErrors)
            {
                foreach (var additionalErrorsValue in additionalError.Value)
                {
                    validationResult.AddError(additionalError.Key, additionalErrorsValue);
                }
            }         
        }
        private void ValidateProperties(object obj, ValidationResult validationResult) 
        {
            Type objectType = obj.GetType();

            this.CacheObjectProperties(objectType);

            var objectProperties = Cache[objectType];
                        
            foreach (var property in objectProperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.Info.GetValue(obj);

                var attributes = property.Attributes;                   


                foreach (var attribute in attributes)
                {
                    var isValid = attribute.IsValid(propertyValue);

                    if (!isValid)
                    {
                        string errorMessage = attribute.FormatErrorMessage(propertyName);

                        validationResult.AddError(propertyName, errorMessage);
                    }
                }
            }    
                      
        }

        private void CacheObjectProperties(Type objectType) 
        {
            if (Cache.ContainsKey(objectType))
            {
                return;
            }         
                       
            var typeProperties = objectType.GetProperties();

            Cache[objectType] = new List<PropertyAttributes>();

            foreach (var property in typeProperties)
            {
                var attributes = property.GetCustomAttributes<ValidationAttribute>();

                Cache[objectType].Add(new PropertyAttributes
                {
                    Name = property.Name,
                    Info = property,
                    Attributes = attributes
                }) ;
            }
            
        }

        private class PropertyAttributes
        {
            public string Name { get; set; }

            public PropertyInfo Info { get; set; }

            public IEnumerable<ValidationAttribute> Attributes{ get; set; }
        }
    }
    
}
