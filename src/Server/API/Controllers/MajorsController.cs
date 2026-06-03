using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/majors")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private IMajorService _majorService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public MajorsController(IMajorService majorService, ILogService logService, IExceptionService exceptionService)
        {
            _majorService = majorService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddMajorAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MajorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<MajorResponse?>> AddMajorAsync(MajorRequest request)
        {
            try
            {
                MajorResponse? response = await _majorService.AddMajorAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Major added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Major.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Major.");
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

        [HttpPut("update/{majorID}", Name = "UpdateMajorAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MajorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<MajorResponse?>> UpdateMajorMajorAsync(MajorRequest request, int majorID)
        {
            try
            {
                MajorResponse? response = await _majorService.UpdateMajorAsync(request, majorID);

                if (response != null)
                {
                    await _logService.LogAsync("Major updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to update Major.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Major.");
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

        [HttpDelete("delete/{majorID}", Name = "DeleteMajorAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteMajorAsync(int majorID)
        {
            try
            {
                bool res = await _majorService.DeleteMajorAsync(majorID);

                if (res)
                {
                    await _logService.LogAsync("Major deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete Major.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Major.");
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

        [HttpGet("get/{majorID}", Name = "GetMajorByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MajorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<MajorResponse>> GetMajorByIDAsync(int majorID)
        {
            try
            {
                MajorResponse? response = await _majorService.GetMajorByIDAsync(majorID);

                if (response != null)
                {
                    await _logService.LogAsync($"Major with ID {majorID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Major with ID {majorID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Major with ID {majorID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedMajorsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MajorResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<MajorResponse>?>> GetPagedMajorsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<MajorResponse>? responses = await _majorService.GetPagedMajorsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Majors fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No majors found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No majors found on page {pageNumber}.");
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
