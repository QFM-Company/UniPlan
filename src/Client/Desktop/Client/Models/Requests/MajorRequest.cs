using Infrastructure.ExternalServices.Validation.Attributes;

namespace Client.Models.Requests
{
    public class MajorRequest : Person
    {
        [Required<string>("اسم التخصص مطلوب")]
        [Length("يجب ألا يزيد طول الاسم عن 100 حرف", 100, 1)]
        public string? MajorName { get; set; }

        [Range<int>("معرف الأختصاص الأب يجب أن لا يكون عدد سالب", 0, int.MaxValue)]
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