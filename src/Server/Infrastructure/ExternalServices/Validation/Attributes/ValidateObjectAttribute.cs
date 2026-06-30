using Core.Interfaces.ExternalServices;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateObjectAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMeesage { get; set; } = "البيانات الموجودة داخل الكائن غير صالحة.";

        public ValidateObjectAttribute() { }

        public bool Check(object? obj)
        {
            if (obj == null) return true; 

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes<Attribute>()
                                         .OfType<IValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    var value = property.GetValue(obj);
                    if (attribute is CompareAttribute compareAttr)
                    {
                        if (!compareAttr.Check(value, obj))
                            return false;
                    }
                    else
                    {
                        if (!attribute.Check(value))
                            return false;
                    }
                }
            }

            return true;
        }
    }
}