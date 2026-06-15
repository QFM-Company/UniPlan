using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Admin")]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AdministratorResponse>> AddAdminAsync(AdministratorRequest request)
        {
            try
            {
                var res = await _adminSevice.AddAdministratorAsync(request);

                if (res != null)
                {
                    await _logService.LogAsync("admin added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to add admin.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add admin.");
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
        public async Task<ActionResult<AdministratorResponse?>> UpdateAdminAsync(AdministratorRequest request, int adminID)
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
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpDelete("delete/{adminID}", Name = "DeleteAdminAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteAdminAsync(int adminID)
        {
            try
            {
                bool res = await _adminSevice.DeleteAdministratorAsync(adminID);

                if (res)
                {
                    await _logService.LogAsync("admin deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete admin.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete admin.");
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AdministratorResponse>> GetAdminByIDAsync(int adminID)
        {
            try
            {
                AdministratorResponse? response = await _adminSevice.GetAdministratorByIdAsync(adminID);

                if (response != null)
                {
                    await _logService.LogAsync($"admin with ID {adminID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"admin with ID {adminID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"admin with ID {adminID} was not found.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedAdminsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AdministratorResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<AdministratorResponse>?>> GetPagedAdminsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<AdministratorResponse>? responses = await _adminSevice.GetPageAdministratorsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"admins fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No admins found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No admins found on page {pageNumber}.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
