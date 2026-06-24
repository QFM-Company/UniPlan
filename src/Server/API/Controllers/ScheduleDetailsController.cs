using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/scheduleDetails")]
    [ApiController]
    public class ScheduleDetailsController : ControllerBase
    {
        private IScheduleDetailService _detailService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public ScheduleDetailsController(IScheduleDetailService detailService, ILogService logService, IExceptionService exceptionService)
        {
            _detailService = detailService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpGet("get/{scheduleID}", Name = "GetScheduleDetailsByScheduleIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ScheduleDetailResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<ScheduleDetailResponse>?>> GetScheduleDetailsByScheduleIDAsync(int scheduleID)
        {
            try
            {
                IEnumerable<ScheduleDetailResponse>? responses = await _detailService.GetScheduleDetailsByScheduleIDAsync(scheduleID);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"ScheduleDetails fetched successfully for schedule ID: {scheduleID}", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"ScheduleDetails with Schedule ID {scheduleID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"ScheduleDetails with Schedule ID {scheduleID} was not found.");
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
