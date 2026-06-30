using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class MajorRequest
    {
        [Required<string>("major name is required")]
        public string? MajorName { get; set; }

        public int ParentMajorID { get; set; }



        public MajorRequest(string majorName, int parentMajorID)
        {
            MajorName = majorName;
            ParentMajorID = parentMajorID;
        }

        public MajorRequest()
        {
            MajorName = null;
            ParentMajorID = default;
        }
    }
}
