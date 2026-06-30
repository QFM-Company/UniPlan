using Business.DTOs.Requests;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/courseSessions")]
    [ApiController]
    public class CourseSessionController : ControllerBase
    {
        private readonly ICourseSessionService _courseSessionService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public CourseSessionController(ICourseSessionService coursesService, ILogService logService, IExceptionService exceptionService)
        {
            _courseSessionService = coursesService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddCourseSessionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseSessionResponse>> AddCourseSessionAsync(CreateCourseSessionRequest request)
        {
            try
            {
                var result = await _courseSessionService.AddCourseSessionAsync(request);

                if (result != null)
                {
                    await _logService.LogAsync("Course Session added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(result);
                }

                await _logService.LogAsync("Failed to add Course Session.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Course Session.");
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

        [HttpPut("update/{courseSessionID}", Name = "UpdateCourseSessionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseSessionResponse>> UpdateCourseSessionAsync(int courseID, UpdateCourseSessionRequest request)
        {
            try
            {
                var result = await _courseSessionService.UpdateCourseSessionAsync(request , courseID);

                if (result)
                {
                    await _logService.LogAsync($"Course Session with ID {courseID} updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(result);
                }

                await _logService.LogAsync($"Failed to update Course Session with ID {courseID}.", ExternalServicesEnums.LogType.Warning);
                return BadRequest($"Failed to update Course Session with ID {courseID}.");
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

        [HttpDelete("delete/{courseSessionID}", Name = "DeleteCourseSessionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteCourseSessionAsync(int courseID)
        {
            try
            {
                bool result = await _courseSessionService.DeleteCourseSessionAsync(courseID);

                if (result)
                {
                    await _logService.LogAsync($"Course Session with ID {courseID} deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(result);
                }

                await _logService.LogAsync($"Failed to delete Course Session with ID {courseID}.", ExternalServicesEnums.LogType.Warning);
                return BadRequest($"Failed to delete Course Session with ID {courseID}.");
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

        [HttpGet("get/{courseSessionID}", Name = "GetCourseSessionByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseSessionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseSessionResponse>> GetCourseSessionByIdAsync(int courseID)
        {
            try
            {
                CourseSessionResponse? response = await _courseSessionService.GetCourseSessionByIDAsync(courseID);

                if (response != null)
                {
                    await _logService.LogAsync($"Course Session with ID {courseID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Course Session with ID {courseID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Course Session with ID {courseID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPageCourseSessionsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CourseSessionResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<CourseSessionResponse>>> GetPageCourseSessionsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<CourseSessionResponse>? responses = await _courseSessionService.GetPagedCourseSessionsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Course Sessions fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No course Sessions found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No course Sessions found on page {pageNumber}.");
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
