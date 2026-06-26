
namespace Business.DTOs.Requests.Update
{
    public class ChangePasswordRequest
    {
        public int AccountID { get; set; }
        public string NewPassword { get; set; }
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
