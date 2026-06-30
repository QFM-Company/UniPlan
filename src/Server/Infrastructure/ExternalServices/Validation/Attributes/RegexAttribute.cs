
using Core.Interfaces.ExternalServices;
using System.Text.RegularExpressions;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public class RegexAttribute : Attribute, IValidationAttribute
    {
        public string ErrorMeesage { get; set; }
        public string Pattern { get; set; }

        public RegexAttribute(string pattern, string errorMeesage)
        {
            Pattern = pattern;
            ErrorMeesage = errorMeesage;
        }

        public bool Check(object? obj)
        {
            if (obj == null)
                return false;

            string value = (string)obj;
            return Regex.IsMatch(value, Pattern);
        }
    }
}
