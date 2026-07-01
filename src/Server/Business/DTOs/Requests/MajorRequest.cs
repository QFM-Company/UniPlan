using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests
{
    public class MajorRequest
    {
        [Required<string>("اسم التخصص مطلوب")]
        [Length("يجب ألا يزيد طول الاسم عن 100 حرف", 100, 1)]
        public string? MajorName { get; set; }

        [Range<int>("معرف الأختصاص الأب يجب أن لا يكون عدد سالب", int.MaxValue, 0)]
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