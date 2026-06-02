namespace Business.DTOs.Requests
{
    public class MajorRequest
    {
        public string MajorName { get; set; } = string.Empty;

        public MajorRequest(string majorName)
        {
            MajorName = majorName;
        }
    }
}
