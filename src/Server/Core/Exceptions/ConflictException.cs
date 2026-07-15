namespace Core.Exceptions
{
    public class ConflictException : ScheduleException
    {
        public ConflictException(string conflictMeesages) : base(conflictMeesages)
        {
        }
    }
}
