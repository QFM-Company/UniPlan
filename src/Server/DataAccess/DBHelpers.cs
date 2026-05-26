using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DBHelpers
    {
        public readonly string? ConnectionString;

        public DBHelpers(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UniPlanConnection");
        }
    }
}
