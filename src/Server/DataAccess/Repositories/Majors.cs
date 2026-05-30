using Core.Entities;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class MajorRepository : IMajorRepository
    {
        private readonly DBHelpers _DBHelpers;
        private readonly ILogService _LogService;
        private readonly IExceptionService _ExceptionService;

        public MajorRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _DBHelpers = dBHelpers;
            _LogService = logService;
            _ExceptionService = exceptionService;
        }

        public async Task<int> AddMajor(Major major)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Majors_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var majorID = new SqlParameter("@MajorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(majorID);
                    command.Parameters.AddWithValue("@MajorName", major.MajorName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (majorID.Value != DBNull.Value && int.TryParse(majorID.Value.ToString(), out int mID))
                    {
                        return mID;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return -1;
        }

        public async Task<bool> UpdateMajor(Major major)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Majors_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@MajorID", major.MajorID);
                    command.Parameters.AddWithValue("@MajorName", major.MajorName);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return false;
        }

        public async Task<bool> DeleteMajor(int majorID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Majors_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@MajorID", majorID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value && bool.TryParse(result.Value.ToString(), out bool res))
                    {
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return false;
        }

        public async Task<Major?> GetMajorByID(int majorID)
        {
            Major? major = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Majors_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MajorID", majorID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            string majorName = reader["MajorName"].ToString() ?? string.Empty;

                            major = new Major(majorID, majorName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return major;
        }

        public async Task<IEnumerable<Major>?> GetPagedMajors(int pageNumber = 1, int pageSize = 10)
        {
            List<Major> majors = new List<Major>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_DBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Majors_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                if (!int.TryParse(reader["MajorID"]?.ToString(), out int majorID))
                                {
                                    majorID = 0;
                                }
                                string majorName = reader["MajorName"].ToString() ?? string.Empty;

                                Major major = new Major(majorID, majorName);
                                majors.Add(major);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(_ExceptionService.GetExceptionMessage(ex), ExternalServicesEnums.LogType.Error);
            }

            return majors;
        }
    }
}