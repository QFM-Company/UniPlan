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

        [HttpPost(Name = "AddTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TimeSlotResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeSlotResponse>> AddTimeSlotAsync(TimeSlotRequest request)
        {
            try
            {
                var res = await _timeSlotsSevice.AddTimeSlotAsync(request);

                if (res != null)
                {
                    await _logService.LogAsync("time slot added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetTimeSlotByIDAsync", new { timeSlotID = res.SlotID} , res);
                }

                await _logService.LogAsync("Failed to add time slot.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add time slot.");
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
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpPut("{timeSlotID}", Name = "UpdateTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> UpdateTimeSlotAsync(TimeSlotRequest request, int timeSlotID)
        {
            try
            {
                if (timeSlotID > 0)
                {
                    var response = await _timeSlotsSevice.UpdateTimeSlotAsync(timeSlotID, request);

                    if (response)
                    {
                        await _logService.LogAsync("time slot updated successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }
                await _logService.LogAsync("Failed to update time slot.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update time slot.");
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
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }


        [HttpDelete("{timeSlotID}", Name = "DeleteTimeSlotAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteTimeSlotAsync(int timeSlotID)
        {
            try
            {
                if (timeSlotID > 0)
                {
                    bool res = await _timeSlotsSevice.DeleteTimeSlotAsync(timeSlotID);

                    if (res)
                    {
                        await _logService.LogAsync("time slot deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(res);
                    }
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


        [HttpGet("{timeSlotID}", Name = "GetTimeSlotByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeSlotResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<TimeSlotResponse>> GetPeriodByIDAsync(int timeSlotID)
        {
            try
            {
                if (timeSlotID > 0)
                {
                    TimeSlotResponse? response = await _timeSlotsSevice.GetTimeSlotByIdAsync(timeSlotID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"time slot with ID {timeSlotID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"time slot with ID {timeSlotID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"time slot with ID {timeSlotID} was not found.");
            }        
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }

        }


        [HttpGet(Name = "GetPagedTimeSlotsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TimeSlotResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<TimeSlotResponse>?>> GetPagedTimeSlotsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    IEnumerable<TimeSlotResponse>? responses = await _timeSlotsSevice.GetPageTimeSlotsAsync(pageNumber, pageSize);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"time slots fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Page Number And Page Size Should be more than 0");

                await _logService.LogAsync($"No time slots found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<TimeSlotResponse>());
            }
            catch (Exception ex)
            {
                await _logService.LogAsync(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
