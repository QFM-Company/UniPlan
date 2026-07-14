using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/wishListItems")]
    [ApiController]
    public class WishListItemController : ControllerBase
    {

        private IWishListItemService _wishListItemService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public WishListItemController(IWishListItemService wishListItemService, ILogService logService, IExceptionService exceptionService)
        {
            _wishListItemService = wishListItemService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddWishListItemAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WishListItemResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<WishListItemResponse?>> AddWishListItemAsync(WishListItemRequest request)
        {
            try
            {
                WishListItemResponse? response = await _wishListItemService.AddWishListItemAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("WishList Item added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetWishListItemByIDAsync", new { wishListItemID = response.ItemID }, response);
                }

                await _logService.LogAsync("Failed to add WishList Item.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("فشل في إضافة عنصر قائمة الرغبات.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return Conflict(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (ValidationException valException)
            {
                await _logService.LogAsync(valException.Message, ExternalServicesEnums.LogType.Error);
                return UnprocessableEntity(valException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
        [HttpDelete("{wishListItemID}", Name = "DeleteWishListItemAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteWishListItemAsync(int wishListItemID)
        {
            try
            {
                if (wishListItemID > 0)
                {
                    bool res = await _wishListItemService.DeleteWishListItemAsync(wishListItemID);

                    if (res)
                    {
                        await _logService.LogAsync("WishList Item deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }

                await _logService.LogAsync("Failed to delete WishList Item.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("فشل في حذف عنصر قائمة الرغبات.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{wishListItemID}", Name = "GetWishListItemByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WishListItemResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<WishListItemResponse>> GetWishListItemByIDAsync(int wishListItemID)
        {
            try
            {
                if (wishListItemID > 0)
                {
                    WishListItemResponse? response = await _wishListItemService.GetWishListItemByIDAsync(wishListItemID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"WishList Item with ID {wishListItemID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("يجب أن يكون المعرف أكبر من 0");

                await _logService.LogAsync($"WishList Item with ID {wishListItemID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"عنصر قائمة الرغبات ذو المعرف {wishListItemID} غير موجود.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}