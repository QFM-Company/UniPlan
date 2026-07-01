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
    [Route("api/wishLists")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly IWishListService _listService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public WishListsController(IWishListService listService, ILogService logService, IExceptionService exceptionService)
        {
            _listService = listService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddWishListAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WishListResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<WishListResponse?>> AddWishListAsync(WishListRequest request)
        {
            try
            {
                WishListResponse? response = await _listService.AddWishListAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("WishList added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add WishList.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add WishList.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (ValidationException valException)
            {
                await _logService.LogAsync(valException.Message, ExternalServicesEnums.LogType.Error);
                return BadRequest(valException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpDelete("delete/{listID}", Name = "DeleteWishListAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteWishListAsync(int listID)
        {
            try
            {
                bool res = await _listService.DeleteWishListAsync(listID);

                if (res)
                {
                    await _logService.LogAsync("WishList deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete WishList.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete WishList.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("get/{listID}", Name = "GetWishListByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WishListResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<WishListResponse>> GetWishListByIDAsync(int listID)
        {
            try
            {
                WishListResponse? response = await _listService.GetWishListByIDAsync(listID);

                if (response != null)
                {
                    await _logService.LogAsync($"WishList with ID {listID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"WishList with ID {listID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"WishList with ID {listID} was not found.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("get/all/{registrationID}", Name = "GetPagedWishListsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WishListResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<WishListResponse>?>> GetWishListsByRegistrationIDAsync(int registrationID)
        {
            try
            {
                IEnumerable<WishListResponse>? responses = await _listService.GetWishListsByRegistrationIDAsync(registrationID);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"WishList fetched successfully for registration ID: {registrationID}", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"WishList with registration ID {registrationID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"WishList with registration ID {registrationID} was not found.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
