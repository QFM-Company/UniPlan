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

        [HttpPost(Name = "AddPeriodAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
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
                return UnprocessableEntity(valException.Message);
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return Conflict(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpDelete("{periodID}", Name = "DeletePeriodAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeletePeriodAsync(int periodID)
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


        [HttpGet("{periodID}", Name = "GetPeriodByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
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
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"period with ID {periodID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"period with ID {periodID} was not found.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet(Name = "GetPagedPeriodsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PeriodResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<PeriodResponse>?>> GetPagedPeriodsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    IEnumerable<PeriodResponse>? responses = await _periodService.GetPagePeriodsAsync(pageNumber, pageSize);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"periods fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Page Number And Page Size Should be more than 0");

                await _logService.LogAsync($"No periods found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<PeriodResponse>());
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
