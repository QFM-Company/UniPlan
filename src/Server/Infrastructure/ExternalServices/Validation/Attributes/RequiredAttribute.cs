using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute<T> : Attribute, IValidationAttribute 
    {
        public string ErrorMeesage { get; set; }

        public RequiredAttribute(string errorMeesage)
        {
            ErrorMeesage = errorMeesage;
        }

        public bool Check(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is string str && string.IsNullOrWhiteSpace(str))
                return false;

            T value = (T)obj;
            return !EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
