
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class CoursesRepository : ICourseRepository
    {

        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public CoursesRepository(DBHelpers dBHelpers, ILogService logService, IExceptionService exceptionService)
        {
            this._dBHelpers = dBHelpers;
            _logService = logService;
        }


        public async Task<int> AddCourseAsync(Course course)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Courses_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var courseID = new SqlParameter("@CourseID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(courseID);
                    command.Parameters.AddWithValue("@CourseName", course.CourseName);
                    command.Parameters.AddWithValue("@CreditHours", course.CreditHours);
                    command.Parameters.AddWithValue("@CourseCode", course.CourseCode);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (courseID.Value != DBNull.Value &&
                        int.TryParse(courseID.Value.ToString(), out int cID))
                    {
                        return cID;
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


        public async Task<bool> UpdateCourseAsync(Course course)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Courses_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);

                    command.Parameters.AddWithValue("@CourseID", course.CourseID);
                    command.Parameters.AddWithValue("@CourseName", course.CourseName);
                    command.Parameters.AddWithValue("@CreditHours", course.CreditHours);
                    command.Parameters.AddWithValue("@CourseCode", course.CourseCode);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value &&
                        bool.TryParse(result.Value.ToString(), out bool res))
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



        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Courses_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@CourseID", courseID);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (result.Value != DBNull.Value &&
                        bool.TryParse(result.Value.ToString(), out bool res))
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


        public async Task<Course?> GetCourseByIDAsync(int courseID)
        {
            Course? course = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Courses_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", courseID);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            course = reader.ToCourse();
                            course.CourseID = courseID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return course;
        }



        public async Task<IEnumerable<Course>> GetPagedCoursesAsync(
               int pageNumber = 1,
               int pageSize = 10)
        {
            List<Course> courses = new();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Courses_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            courses.Add(reader.ToCourse());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return courses;
        }


    }
}
