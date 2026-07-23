using Core.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.Validation.Attributes;
using System.Reflection;

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

                foreach (ValidationAttribute attribute in property.GetCustomAttributes<ValidationAttribute>())
                {
                    if (!attribute.Check(value))
                    {
                        errors.Add(attribute.ErrorMessage);
                        break;
                    }
                }

                foreach (CompareAttribute attribute in property.GetCustomAttributes<CompareAttribute>())
                {
                    object? otherValue = type.GetProperties().FirstOrDefault(p => p.Name == attribute.OtherPropertyName)?.
                                       GetValue(obj, null);

                    if (!attribute.Check(value, otherValue))
                    {
                        errors.Add(attribute.ErrorMessage);
                        break;
                    }
                }

                if (value != null && property.PropertyType.IsClass && property.PropertyType.Name.Contains("Request"))
                {
                    ExecuteValidation(value, errors);
                }
            }
        }
    }
}
