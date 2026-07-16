namespace Core.Entities
{
    public class SessionOverlapComparer : IComparer<CourseSession>
    {
        public string? ConflictMessage { get; private set; } 

        public int Compare(CourseSession? x, CourseSession? y)
        {
            if (x == null || y == null)
                return 0;

            if(x.OverlapsWith(y))
            {
                ConflictMessage = $"{x}\n{y}";
                return 0;
            }

            return x.StartTime.CompareTo(y.StartTime);
        }
    }
}
