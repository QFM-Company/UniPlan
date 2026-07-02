namespace Core.Entities
{
    public class Major
    {
        public int MajorID { get; set; }

        public string? MajorName { get; set; } = string.Empty;

        public int ParentMajorID { get; set; }

        public Major(int majorID, string? majorName)
        {
            MajorID = majorID;
            MajorName = majorName;
            ParentMajorID = default;
        }

        public Major(int majorID, string? majorName, int parentMajorID)
        {
            MajorID = majorID;
            MajorName = majorName;
            ParentMajorID = parentMajorID;
        }

        public Major(int majorID)
        {
            MajorID = majorID;
            MajorName = string.Empty;
            ParentMajorID = default;
        }
    }
}