using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;


        public HallRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddHallAsync(Hall hall)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Halls_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var hallID = new SqlParameter("@HallID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(hallID);


                    command.Parameters.AddWithValue("@HallName", hall.HallName);
                    command.Parameters.AddWithValue("@Building", hall.Building ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Floor", hall.Floor != 0 ? hall.Floor : DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedByAdminID", hall.CreatedByAdminID != 0 ? hall.CreatedByAdminID : DBNull.Value);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();


                    if (hallID.Value != DBNull.Value && int.TryParse(hallID.Value.ToString(), out int hID))
                    {
                        return hID;
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

        public async Task<bool> UpdateHallAsync(Hall hall)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Halls_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);

                    command.Parameters.AddWithValue("@HallID", hall.HallID);
                    command.Parameters.AddWithValue("@HallName", hall.HallName);
                    command.Parameters.AddWithValue("@Building", hall.Building ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Floor", hall.Floor != 0 ? hall.Floor : DBNull.Value);

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

        public async Task<bool> DeleteHallAsync(int hallID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Halls_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@HallID", hallID);

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

        public async Task<Hall?> GetHallByIDAsync(int hallID)
        {
            Hall? hall = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Halls_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@HallID", hallID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            hall = reader.ToHall();
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return hall;
        }

        public async Task<IEnumerable<Hall>?> GetPagedHallsAsync(int pageNumber = 1, int pageSize = 10)
        {
            List<Hall>? halls = new List<Hall>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_Halls_GetAll", connection))
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
                                Hall hall = reader.ToHall();
                                halls.Add(hall);
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

            return halls;
        }

    }
}
