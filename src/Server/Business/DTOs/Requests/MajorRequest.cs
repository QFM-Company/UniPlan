namespace Business.DTOs.Requests
{
    public class MajorRequest
    {
        public string MajorName { get; set; } = string.Empty;

        public int ParentMajorID { get; set; }

        public MajorRequest(string majorName, int parentMajorID)
        {
            MajorName = majorName;
            ParentMajorID = parentMajorID;
        }
    }
}
