using Microsoft.Data.SqlClient;
using Core.Interfaces.ExternalServices;

namespace Infrastructure.ExternalServices
{
    public class ExceptionService : IExceptionService
    {
        private string _GetCustomSqlExceptionMessage(SqlException ex)
        {
            string entityName = ( (ex.Number / 100) * 100 ) switch
            {
                50100 => "People",
                50200 => "Admin",
                50300 => "Student",
                50400 => "Account",
                50500 => "Major",
                50600 => "Periods",
                50700 => "TimeSlots",
                50800 => "Halls",
                _ => "Unknown Entity"
            };

            string exceptionMessage = (ex.Number % 100) switch
            {
                1 => $"Validation error occurred for '{entityName}'. Please check the inputs.",
                2 => $"This '{entityName}' already exists. Please enter unique data.",
                3 => $"The requested '{entityName}' does not exist.",
                4 => $"This '{entityName}' is related to other data and cannot be modified or deleted.",
                5 => $"Permission denied for this '{entityName}' operation.",
                _ => $"An error occurred in '{entityName}'."
            };

            return $"{exceptionMessage}\n(Error code: {ex.Number})";
        }

        private string _GetSqlExceptionMessage(SqlException ex)
        {
            if (ex.Number >= 50000)
                return _GetCustomSqlExceptionMessage(ex);

            switch (ex.Number)
            {
                case 2601: // Duplicated key row error
                    return $"A record with the same value already exists. Please enter unique data.\n(Error code: {ex.Number})";

                case 547: // Foreign key violation
                    return $"This record is linked to other data and cannot be deleted or modified.\n(Error code: {ex.Number})";

                case 4060: // Invalid Database
                    return $"The database requested is not available.\n(Error code: {ex.Number})";

                case 18456: // Login failed
                    return $"Database login failed. Please check your username and password.\n(Error code: {ex.Number})";

                case 208: // Invalid object name (table/view not found)
                    return $"A required database object was not found. Please contact the system administrator.\n(Error code: {ex.Number})";

                case 207: // Invalid column name
                    return $"An invalid column name was referenced in the query.\n(Error code: {ex.Number})";

                case 8152: // String or binary data would be truncated
                    return $"One of the fields contains too much text. Please shorten your input.\n(Error code: {ex.Number})";

                case 53: // Cannot connect to server
                    return $"Cannot connect to the database server. Please check your network connection.\n(Error code: {ex.Number})";

                case -2: // Timeout expired
                    return $"The database operation took too long and timed out. Please try again.\n(Error code: {ex.Number})";

                case 1205: // Deadlock
                    return $"A database conflict occurred. Please try the operation again.\n(Error code: {ex.Number})"; 
                default:
                    // Generic fallback message
                    return $"{ex.Message}\n(Error code: {ex.Number})";
            }
        }
        
        public string GetExceptionMessage(Exception ex)
        {
            switch (ex)
            {
                case SqlException sqlEx:
                    return _GetSqlExceptionMessage(sqlEx);
                case FormatException formatException:
                    return $"The entered value has an invalid format. Please check your input and try again.";

                case FileNotFoundException fileNotFoundException:
                    return "The required file could not be found. Please make sure the file exists.";

                case IOException iOException:
                    return "A file operation failed. Please check that the file is not in use or locked.";

                case ArgumentNullException argumentNullException:
                    return "Some required information is missing. Please fill all required fields.";

                case InvalidOperationException invalidOperationException:
                    return "The requested operation is not valid in the current state.";

                case ArgumentException argument:
                    return "An invalid argument or value was provided.";

                default:
                    return $"{ex.Message}";
            }
        }

    }
}
