namespace Client.Models.Responses
{
    public class MajorResponse : BaseModel
    {
        public int MajorID { get; set; }

        public string? MajorName { get; set; } = string.Empty;

        public MajorResponse(int majorID, string? majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
        }

        public MajorResponse()
        {
            MajorID = -1;
            MajorName = string.Empty;
        }
    }
}
