using Infrastructure.ExternalServices.Validation.Attributes;
using Infrastructure.ExternalServices.Validation.Enums;

namespace Business.DTOs.Requests.Update
{
    public class ChangePasswordRequest
    {
        [Required<int>("„⁄—› «·Õ”«» „ÿ·Ê»")]
        [Range<int>("ÌÃ» √‰ ÌﬂÊ‰ «·„⁄—› √ﬂ»— „‰ 0", 1, int.MaxValue)]
        public int AccountID { get; set; }

        [Required<string>("ﬂ·„… «·„—Ê— «·ÃœÌœ… „ÿ·Ê»…")]
        [Length("ÌÃ» √‰  ﬂÊ‰ ﬂ·„… «·„—Ê— »Ì‰ 8 Ê 50 Õ—›«", 50, 8)]
        [Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
            "ÌÃ» √‰  Õ ÊÌ ﬂ·„… «·„—Ê— ⁄·Ï Õ—› ﬂ»Ì— ÊÕ—› ’€Ì— Ê—ﬁ„ Ê—„“ Œ«’")]
        public string NewPassword { get; set; }

        [Required<string>("ﬂ·„… «·„—Ê— «·ﬁœÌ„… „ÿ·Ê»…")]
        [Length("ÌÃ» √‰  ﬂÊ‰ ﬂ·„… «·„—Ê— »Ì‰ 8 Ê 50 Õ—›«", 50, 8)]
        [Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$",
            "ÌÃ» √‰  Õ ÊÌ ﬂ·„… «·„—Ê— ⁄·Ï Õ—› ﬂ»Ì— ÊÕ—› ’€Ì— Ê—ﬁ„ Ê—„“ Œ«’")]
        [Compare(nameof(NewPassword), ComparisonType.NotEqual, "ÌÃ» √‰  ﬂÊ‰ ﬂ·„… «·„—Ê— «·ÃœÌœ… „Œ ·›… ⁄‰ «·ﬁœÌ„…")]
        public string OLdPassword { get; set; } 

        public ChangePasswordRequest()
        {
            AccountID = -1;
            NewPassword = string.Empty;
            OLdPassword = string.Empty;
        }

        public ChangePasswordRequest(int accountID, string newPassword, string oLdPassword)
        {
            AccountID = accountID;
            NewPassword = newPassword;
            OLdPassword = oLdPassword;
        }
    }
}