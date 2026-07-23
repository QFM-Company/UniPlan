using System.Text.RegularExpressions;

namespace Infrastructure.ExternalServices.Validation.Attributes
{
    public class RegexAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }

        public RegexAttribute(string pattern, string errorMeesage) : base(errorMeesage)
        {
            Pattern = pattern;
        }

        public override bool Check(object? obj)
        {
            if (obj == null)
                return false;

            string value = (string)obj;
            return Regex.IsMatch(value, Pattern);
        }
    }
}
