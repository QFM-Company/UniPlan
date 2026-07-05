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
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public CoursesController(ICoursesService coursesService, ILogService logService, IExceptionService exceptionService)
        {
            _coursesService = coursesService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddCourseAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CourseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseResponse>> AddCourseAsync(CourseRequest request)
        {
            try
            {
                var result = await _coursesService.AddCourseAsync(request);

                if (result != null)
                {
                    await _logService.LogAsync("Course added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtAction(nameof(GetCourseByIdAsync), new { id = result.CourseID }, result);
                }

                await _logService.LogAsync("Failed to add Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Course.");
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
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpPut("update/{courseID}", Name = "UpdateCourseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseResponse>> UpdateCourseAsync(int courseID, CourseRequest request)
        {
            try
            {
                if (courseID > 0)
                {
                    var result = await _coursesService.UpdateCourseAsync(courseID, request);

                    if (result != null)
                    {
                        await _logService.LogAsync($"Course with ID {courseID} updated successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(result);
                    }
                }
                await _logService.LogAsync($"Failed to update Course with ID {courseID}.", ExternalServicesEnums.LogType.Warning);
                return BadRequest($"Failed to update Course with ID {courseID}.");
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
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpDelete("delete/{courseID}", Name = "DeleteCourseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteCourseAsync(int courseID)
        {
            try
            {
                if (courseID > 0)
                {
                    bool result = await _coursesService.DeleteCourseAsync(courseID);

                    if (result)
                    {
                        await _logService.LogAsync($"Course with ID {courseID} deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(result);
                    }
                }
                await _logService.LogAsync($"Failed to delete Course with ID {courseID}.", ExternalServicesEnums.LogType.Warning);
                return BadRequest($"Failed to delete Course with ID {courseID}.");
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

        [HttpGet("get/{courseID}", Name = "GetCourseByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseResponse>> GetCourseByIdAsync(int courseID)
        {
            try
            {
                if (courseID > 0)
                {
                    CourseResponse? response = await _coursesService.GetCourseByIdAsync(courseID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"Course with ID {courseID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                await _logService.LogAsync($"Course with ID {courseID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Course with ID {courseID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPageCoursesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CourseResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<CourseResponse>>> GetPageCoursesAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<CourseResponse> responses = await _coursesService.GetPageCoursesAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Courses fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No courses found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No courses found on page {pageNumber}.");
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