using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class CourseOfferingRepository : ICourseOfferingRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public CourseOfferingRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddCourseOfferingAsync(CourseOffering offering)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CourseOfferings_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var offeringID = new SqlParameter("@OfferingID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(offeringID);
                    command.Parameters.AddWithValue("@SectionNumber", offering.SectionNumber);
                    command.Parameters.AddWithValue("@TermID", offering.Term?.TermID);
                    command.Parameters.AddWithValue("@LectureID", offering.Lecture?.LectureID);
                    command.Parameters.AddWithValue("@CreatedByAdminID", offering.CreatedByAdminID);
                    command.Parameters.AddWithValue("@CourseID", offering.Lecture?.Course?.CourseID);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (offeringID.Value != DBNull.Value && int.TryParse(offeringID.Value.ToString(), out int mID))
                    {
                        return mID;
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return -1;
        }

        public async Task<bool> UpdateCourseOfferingAsync(CourseOffering offering)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CourseOfferings_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@OfferingID", offering.OfferingID);
                    command.Parameters.AddWithValue("@SectionNumber", offering.SectionNumber);
                    command.Parameters.AddWithValue("@TermID", offering.Term?.TermID);
                    command.Parameters.AddWithValue("@LectureID", offering.Lecture?.LectureID);
                    command.Parameters.AddWithValue("@CourseID", offering.Lecture?.Course?.CourseID);

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
                await _logService.LogAsync(ex);
                throw;
            }

            return false;
        }

        public async Task<bool> DeleteCourseOfferingAsync(int offeringID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CourseOfferings_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@OfferingID", offeringID);

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
                await _logService.LogAsync(ex);
                throw;
            }

            return false;
        }

        public async Task<CourseOffering?> GetCourseOfferingByIDAsync(int offeringID)
        {
            CourseOffering? offering = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CourseOfferings_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferingID", offeringID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            offering = reader.ToCourseOffering();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return offering;
        }

        public async Task<IEnumerable<CourseOffering>?> GetPagedCourseOfferingsAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<CourseOffering> offerings = new List<CourseOffering>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CourseOfferings_GetAll", connection))
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
                                CourseOffering offering = reader.ToCourseOffering();
                                offerings.Add(offering);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return offerings;
        }
    }
}
