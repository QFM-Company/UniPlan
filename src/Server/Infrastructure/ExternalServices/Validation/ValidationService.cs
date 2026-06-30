using Core.Interfaces.ExternalServices;
using System.Reflection;
using Core.Exceptions;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Infrastructure.ExternalServices.Validation
{
    public class ValidationService : IValidationService 
    {
        public void Validate<T>(T dto) where T : class
        {
            if (dto == null) 
                return;

            List<string> errors = new List<string>();
            ExecuteValidation(dto, errors);

            if (errors.Any())
            {
                throw new ValidationException(string.Join("\n", errors));
            }
        }

        private void ExecuteValidation(object obj, List<string> errors)
        {
            if (obj == null) 
                return;

            Type type = obj.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                object? value = property.GetValue(obj, null);

                foreach (var item in property.GetCustomAttributes())
                {
                    if (item is IValidationAttribute attribute)
                    {
                        if (!attribute.Check(value))
                        {
                            errors.Add(attribute.ErrorMeesage);
                        }
                    }
                }

                if (value != null && property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    ExecuteValidation(value, errors);
                }
            }
        }
    }
}
