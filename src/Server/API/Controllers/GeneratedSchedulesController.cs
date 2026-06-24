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
    [Route("api/generatedSchedules")]
    [ApiController]
    public class GeneratedSchedulesController : ControllerBase
    {
        private IGeneratedScheduleService _scheduleService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public GeneratedSchedulesController(IGeneratedScheduleService scheduleService, ILogService logService, IExceptionService exceptionService)
        {
            _scheduleService = scheduleService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddGeneratedScheduleAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneratedScheduleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<GeneratedScheduleResponse?>> AddGeneratedScheduleAsync(GeneratedScheduleRequest request)
        {
            try
            {
                GeneratedScheduleResponse? response = await _scheduleService.AddGeneratedScheduleAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("GeneratedSchedule added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add GeneratedSchedule.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add GeneratedSchedule.");
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

        [HttpGet("get/{listID}", Name = "GetGeneratedScheduleByWishListIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneratedScheduleResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<GeneratedScheduleResponse>> GetGeneratedScheduleByWishListIDAsync(int listID)
        {
            try
            {
                GeneratedScheduleResponse? response = await _scheduleService.GetGeneratedScheduleByWishListIDAsync(listID);

                if (response != null)
                {
                    await _logService.LogAsync($"GeneratedSchedule with list ID {listID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"GeneratedSchedule with list ID {listID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"GeneratedSchedule with list ID {listID} was not found.");
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
