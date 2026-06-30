using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Services;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/timeSlots")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        private ITimeSlotsService _timeSlotsSevice;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public TimeSlotsController(ITimeSlotsService timeSlotsSevice, ILogService logService, IExceptionService exceptionService)
        {
            _timeSlotsSevice = timeSlotsSevice;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeSlotResponse>> AddTimeSlotAsync(TimeSlotRequest request)
        {
            try
            {
                var res = await _timeSlotsSevice.AddTimeSlotAsync(request);

                if (res != null)
                {
                    await _logService.LogAsync("time slot added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to add time slot.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add time slot.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpPut("update/{timeSlotID}", Name = "UpdateTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSlotResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeSlotResponse?>> UpdateTimeSlotAsync(TimeSlotRequest request, int timeSlotID)
        {
            try
            {
                var response = await _timeSlotsSevice.UpdateTimeSlotAsync(timeSlotID , request);

                if (response != null)
                {
                    await _logService.LogAsync("time slot updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to update time slot.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update time slot.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpDelete("delete/{timeSlotID}", Name = "DeleteTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteTimeSlotAsync(int timeSlotID)
        {
            try
            {
                bool res = await _timeSlotsSevice.DeleteTimeSlotAsync(timeSlotID);

                if (res)
                {
                    await _logService.LogAsync("time slot deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete time slot.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete time slot.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{timeSlotID}", Name = "GetTimeSlotByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSlotResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeSlotResponse>> GetPeriodByIDAsync(int timeSlotID)
        {
            try
            {
                TimeSlotResponse? response = await _timeSlotsSevice.GetTimeSlotByIdAsync(timeSlotID);

                if (response != null)
                {
                    await _logService.LogAsync($"time slot with ID {timeSlotID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"time slot with ID {timeSlotID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"time slot with ID {timeSlotID} was not found.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedTimeSlotsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TimeSlotResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<TimeSlotResponse>?>> GetPagedTimeSlotsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<TimeSlotResponse>? responses = await _timeSlotsSevice.GetPageTimeSlotsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"time slots fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No time slots found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No time slots found on page {pageNumber}.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
