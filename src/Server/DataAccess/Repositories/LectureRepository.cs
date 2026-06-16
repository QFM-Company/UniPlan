using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using DataAccess.Mapping;

namespace DataAccess.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public LectureRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddLectureAsync(Lecture lecture)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Lectures_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var lectureID = new SqlParameter("@LectureID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(lectureID);
                    command.Parameters.AddWithValue("@LectureType", lecture.LectureType);
                    command.Parameters.AddWithValue("@DurationValue", lecture.DurationValue);
                    command.Parameters.AddWithValue("@CourseID", lecture.Course?.CourseID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (lectureID.Value != DBNull.Value && int.TryParse(lectureID.Value.ToString(), out int mID))
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

        public async Task<bool> UpdateLectureAsync(Lecture lecture)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Lectures_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@LectureID", lecture.LectureID);
                    command.Parameters.AddWithValue("@LectureType", lecture.LectureType);
                    command.Parameters.AddWithValue("@DurationValue", lecture.DurationValue);
                    command.Parameters.AddWithValue("@CourseID", lecture.Course?.CourseID);

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

        public async Task<bool> DeleteLectureAsync(int lectureID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Lectures_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@LectureID", lectureID);

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

        public async Task<Lecture?> GetLectureByIDAsync(int lectureID)
        {
            Lecture? lecture = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Lectures_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LectureID", lectureID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            lecture = reader.ToLecture();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return lecture;
        }

        public async Task<IEnumerable<Lecture>?> GetPagedLecturesAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<Lecture> lectures = new List<Lecture>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Lectures_GetAll", connection))
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
                                Lecture lecture = reader.ToLecture();
                                lectures.Add(lecture);
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

            return lectures;
        }
    }
}
