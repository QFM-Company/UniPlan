namespace Core.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string conflictMeesages) : base(conflictMeesages)
        {
        }
    }
}
