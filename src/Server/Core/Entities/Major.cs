namespace Core.Entities
{
    public class Major
    {
        public int MajorID { get; set; }
        public string? MajorName { get; set; } = string.Empty;
        public Major(int majorID, string? majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
        }

        public Major() 
        {
            MajorID = -1;
            MajorName = string.Empty;
        }

        public Major(int majorID)
        {
            MajorID = majorID;
        }
    }
}