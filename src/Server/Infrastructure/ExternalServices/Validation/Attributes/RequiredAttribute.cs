namespace Infrastructure.ExternalServices.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute<T> : ValidationAttribute 
    {
        public RequiredAttribute(string errorMeesage) : base(errorMeesage)
        {
        }

        public override bool Check(object? obj)
        {
            if (obj == null)
                return false;

            if (obj is string str && string.IsNullOrWhiteSpace(str))
                return false;

            if (obj is T value)
            {
                return !EqualityComparer<T>.Default.Equals(value, default(T));
            }

            return true;
        }
    }
}
