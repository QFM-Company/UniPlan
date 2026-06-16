
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class CoursePrequstRepository : ICoursePrequsetRepository
    {
        public DBHelpers _dBHelpers;

        public ILogService _logService;

        public CoursePrequstRepository(DBHelpers dBHelpers, ILogService logService)
        {
            this._dBHelpers = dBHelpers;
            _logService = logService;
        }


        public async Task<int> AddPrequestAsync(CoursePrerequisites coursePrequst)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_CoursePrerequisites_Insert", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var preRequestID = new SqlParameter("@PrerequisiteID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(preRequestID);
                        command.Parameters.AddWithValue("@CourseID", coursePrequst.Course?.CourseID);
                        command.Parameters.AddWithValue("@PrerequisiteCourseID", coursePrequst.PreRequestCourse?.CourseID);
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                        if (preRequestID.Value != DBNull.Value &&
                            int.TryParse(preRequestID.Value.ToString(), out int pID))
                        {
                            return pID;
                        }
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


        public async Task<bool> DeletePrequestAsync(int coursePrequestID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CoursePrerequisites_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@PrerequisiteID", coursePrequestID);

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



        public async Task<CoursePrerequisites?> GetCoursePrerequisitesByIDAsync(int coursePrequestID)
        {
            CoursePrerequisites? coursePrequest = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CoursePrerequisites_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PrerequisiteID", coursePrequestID);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            
                            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

                            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);
                            int.TryParse(reader["MajorID"]?.ToString(), out int majorID);
                            string majorName = reader["MajorName"].ToString() ?? string.Empty;
                            int.TryParse(reader["CourseID"]?.ToString(), out int mainCourseID);

                            Major major = new Major(majorID, majorName);

                            Course mainCourse = new Course(mainCourseID ,courseName , creditHours , major);
                           


                            string courseName2 = reader["CourseName2"]?.ToString() ?? string.Empty;

                            int.TryParse(reader["CreditHours2"]?.ToString(), out int creditHours2);
                            int.TryParse(reader["MajorID2"]?.ToString(), out int majorID2);
                            string majorName2 = reader["MajorName2"].ToString() ?? string.Empty;
                            int.TryParse(reader["CourseID2"]?.ToString(), out int PreCourseID2);

                            Major major2 = new Major(majorID2, majorName2);

                            Course preCourse = new Course(PreCourseID2 , courseName2 , creditHours2 , major2);
                            
                            
                            coursePrequest = new CoursePrerequisites(
                                coursePrequestID ,
                                 mainCourse ,
                                 preCourse
                                 );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return coursePrequest;
        }




        public async Task<IEnumerable<CoursePrerequisites>> GetCoursePrerequisitesPagedAsync(int PageNumber , int PageSize)
        {

            List<CoursePrerequisites> coursesPre = new();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_CoursePrerequisites_GetAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    command.Parameters.AddWithValue("@PageSize", PageSize);

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            string courseName = reader["CourseName"]?.ToString() ?? string.Empty;

                            int.TryParse(reader["CreditHours"]?.ToString(), out int creditHours);
                            int.TryParse(reader["MajorID"]?.ToString(), out int majorID);
                            string majorName = reader["MajorName"].ToString() ?? string.Empty;
                            int.TryParse(reader["CourseID"]?.ToString(), out int mainCourseID);

                            Major major = new Major(majorID, majorName);

                            Course mainCourse = new Course(mainCourseID, courseName, creditHours, major);



                            string courseName2 = reader["CourseName2"]?.ToString() ?? string.Empty;

                            int.TryParse(reader["CreditHours2"]?.ToString(), out int creditHours2);
                            int.TryParse(reader["MajorID2"]?.ToString(), out int majorID2);
                            string majorName2 = reader["MajorName2"].ToString() ?? string.Empty;
                            int.TryParse(reader["CourseID2"]?.ToString(), out int PreCourseID2);

                            Major major2 = new Major(majorID2, majorName2);

                            Course preCourse = new Course(PreCourseID2, courseName2, creditHours2, major2);

                            int.TryParse(reader["PrerequisiteID"]?.ToString(), out int PrerequisiteID);


                            coursesPre.Add( new CoursePrerequisites(
                                 PrerequisiteID,
                                 mainCourse,
                                 preCourse
                                 ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return coursesPre;
        }
    }
}
