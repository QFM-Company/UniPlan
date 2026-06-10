namespace Business.DTOs.Responses
{
    public class MajorResponse
    {
        public int MajorID { get; set; }
        public string? MajorName { get; set; } = string.Empty;
     
        public MajorResponse(int majorID, string? majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
        }
    }
}
