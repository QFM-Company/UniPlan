using Business.DTOs.Requests.Create;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private IAdministratorService _adminSevice;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public AdministratorController(IAdministratorService administratorService, ILogService logService, IExceptionService exceptionService)
        {
            _adminSevice = administratorService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddAdminAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AdministratorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AdministratorResponse>> AddAdminAsync(CreateAdministratorRequest request)
        {
            try
            {
                var res = await _adminSevice.AddAdministratorAsync(request);

                if (res != null)
                {
                    await _logService.LogAsync("admin added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetAdminByIDAsync", new { adminID = res.AdminID } , res);
                }

                await _logService.LogAsync("Failed to add admin.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add admin.");
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
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpPut("update/{adminID}", Name = "UpdateAdminAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdministratorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AdministratorResponse?>> UpdateAdminAsync(CreateAdministratorRequest request, int adminID)
        {
            try
            {
                var response = await _adminSevice.UpdateAdministratorAsync(adminID, request);

                if (response != null)
                {
                    await _logService.LogAsync("admin updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to update admin.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update admin.");
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
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpDelete("delete/{adminID}", Name = "DeleteAdminAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteAdminAsync(int adminID)
        {
            try
            {
                if (adminID > 0)
                {
                    bool res = await _adminSevice.DeleteAdministratorAsync(adminID);

                    if (res)
                    {
                        await _logService.LogAsync("admin deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(res);
                    }
                }

                await _logService.LogAsync("Failed to delete admin.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete admin.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{adminID}", Name = "GetAdminByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdministratorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AdministratorResponse>> GetAdminByIDAsync(int adminID)
        {
            try
            {
                if (adminID > 0)
                {
                    AdministratorResponse? response = await _adminSevice.GetAdministratorByIdAsync(adminID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"admin with ID {adminID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"admin with ID {adminID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"admin with ID {adminID} was not found.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedAdminsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AdministratorResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<AdministratorResponse>?>> GetPagedAdminsAsync(int pageNumber, int pageSize)
        {
            try
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    IEnumerable<AdministratorResponse>? responses = await _adminSevice.GetPageAdministratorsAsync(pageNumber, pageSize);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"admins fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Page Number And Page Size Should be more than 0");

                await _logService.LogAsync($"No admins found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<AdministratorResponse>());
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
