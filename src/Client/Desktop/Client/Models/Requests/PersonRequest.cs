using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class PersonRequest : Person
    {
        [Required<string>("الاسم الأول مطلوب")]
        [Length("يجب ألا يتجاوز الاسم الأول 50 حرفًا", 50, 1)]
        public string FirstName { get; set; } = string.Empty;

        [Length("يجب ألا يتجاوز الاسم الأوسط 50 حرفًا", 50, 0)]
        public string MiddleName { get; set; } = string.Empty;

        [Required<string>("الاسم الأخير مطلوب")]
        [Length("يجب ألا يتجاوز الاسم الأخير 50 حرفًا", 50, 1)]
        public string LastName { get; set; } = string.Empty;

        public PersonRequest(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public PersonRequest()
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }
    }
}