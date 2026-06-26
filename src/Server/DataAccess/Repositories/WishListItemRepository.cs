using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using DataAccess.Mapping;
using Microsoft.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class WishListItemRepository : IWishListItemRepository
    {
        private readonly DBHelpers _dBHelpers;
        private readonly ILogService _logService;

        public WishListItemRepository(DBHelpers dBHelpers, ILogService logService)
        {
            _dBHelpers = dBHelpers;
            _logService = logService;
        }

        public async Task<int> AddWishListItemAsync(WishListItem wishListItem)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_WishListItems_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var wishListItemID = new SqlParameter("@ItemID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(wishListItemID);
                    command.Parameters.AddWithValue("@WishListID", wishListItem.WishList?.WishListID);
                    command.Parameters.AddWithValue("@CourseID", wishListItem.Course?.CourseID);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    if (wishListItemID.Value != DBNull.Value && int.TryParse(wishListItemID.Value.ToString(), out int mID))
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

        public async Task<bool> DeleteWishListItemAsync(int wishListItemID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_WishListItems_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var result = new SqlParameter("@Result", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(result);
                    command.Parameters.AddWithValue("@ItemID", wishListItemID);

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

        public async Task<WishListItem?> GetWishListItemByIDAsync(int wishListItemID)
        {
            WishListItem? wishListItem = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_WishListItems_GetById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ItemID", wishListItemID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null && await reader.ReadAsync())
                        {
                            wishListItem = reader.ToWishListItem();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                throw;
            }

            return wishListItem;
        }

        public async Task<IEnumerable<WishListItem>?> GetWishListItemsByWishListIDAsync(int wishListID)
        {
            List<WishListItem> wishListItems = new List<WishListItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_dBHelpers.ConnectionString))
                using (SqlCommand command = new SqlCommand("SP_WishListItems_GetByWishListId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@WishListID", wishListID);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader != null)
                        {
                            while (await reader.ReadAsync())
                            {
                                wishListItems.Add(reader.ToWishListItem());
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

            return wishListItems;
        }
    }
}
