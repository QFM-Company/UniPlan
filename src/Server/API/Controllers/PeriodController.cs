using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/periods")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private IPeriodService _periodService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public PeriodController(IPeriodService periodService, ILogService logService, IExceptionService exceptionService)
        {
            _periodService = periodService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddPeriodAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<PeriodResponse>> AddPeriodAsync(PeriodRequest request)
        {
            try
            {
                var res = await _periodService.AddPeriodAsync(request);

                if (res != null)
                {
                    await _logService.LogAsync("Period added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetPeriodByIDAsync", new { periodID = res.PeriodID} , res);
                }

                await _logService.LogAsync("Failed to add period.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add period.");
            }
            catch (ValidationException valException)
            {
                await _logService.LogAsync(valException.Message, ExternalServicesEnums.LogType.Error);
                return BadRequest(valException.Message);
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


        [HttpDelete("delete/{periodID}", Name = "DeletePeriodAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeletePeriodAsync(int periodID)
        {
            try
            {
                if (periodID > 0)
                {
                    bool res = await _periodService.DeletePeriodAsync(periodID);

                    if (res)
                    {
                        await _logService.LogAsync("period deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }
                await _logService.LogAsync("Failed to delete period.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete period.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{periodID}", Name = "GetPeriodByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<PeriodResponse>> GetPeriodByIDAsync(int periodID)
        {
            try
            {
                if (periodID > 0)
                {
                    PeriodResponse? response = await _periodService.GetPeriodByIdAsync(periodID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"period with ID {periodID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                await _logService.LogAsync($"period with ID {periodID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"period with ID {periodID} was not found.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedPeriodsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PeriodResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<PeriodResponse>?>> GetPagedPeriodsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<PeriodResponse>? responses = await _periodService.GetPagePeriodsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"periods fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No periods found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No periods found on page {pageNumber}.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
