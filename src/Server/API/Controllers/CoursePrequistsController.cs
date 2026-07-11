using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/coursePrequists")]
    [ApiController]
    public class CoursePrequistsController : ControllerBase
    {
        private readonly ICoursePrequistService _coursePrequistsService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public CoursePrequistsController(ICoursePrequistService coursesPreService, ILogService logService, IExceptionService exceptionService)
        {
            _coursePrequistsService = coursesPreService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddCoursePrequistAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CoursePrerequisiteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CoursePrerequisiteResponse>> AddCoursePrequistAsync(CoursePrerequisiteRequest request)
        {
            try
            {
                var result = await _coursePrequistsService.AddCoursePrequistAsync(request);

                if (result != null)
                {
                    await _logService.LogAsync("Course Prequist added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetCoursePrequistByIdAsync", new { coursePrequistID = result.PreRequestID }, result);
                }

                await _logService.LogAsync("Failed to add Course Prequist.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Course Prequist.");
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
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpDelete("{coursePrequistID}", Name = "DeleteCoursePrequistAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteCoursePrequistAsync(int coursePrequistID)
        {
            try
            {
                if (coursePrequistID > 0)
                {
                    bool result = await _coursePrequistsService.DeleteCoursePrequistAsync(coursePrequistID);

                    if (result)
                    {
                        await _logService.LogAsync($"Course prequist with ID {coursePrequistID} deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }
                await _logService.LogAsync($"Failed to delete Course Prequist with ID {coursePrequistID}.", ExternalServicesEnums.LogType.Warning);
                return BadRequest($"Failed to delete Course prequist with ID {coursePrequistID}.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{coursePrequistID}", Name = "GetCoursePrequistByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CoursePrerequisiteResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CoursePrerequisiteResponse>> GetCoursePrequistByIdAsync(int coursePrequistID)
        {
            try
            {
                if (coursePrequistID > 0)
                {
                    CoursePrerequisiteResponse? response = await _coursePrequistsService.GetCoursePrequistByIDAsync(coursePrequistID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"Course Prequist with ID {coursePrequistID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"Course Prequist with ID {coursePrequistID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Course Prequist with ID {coursePrequistID} was not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet(Name = "GetPageCoursesPrequistsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CoursePrerequisiteResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<CoursePrerequisiteResponse>>> GetPageCoursesPrequistsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                if (pageNumber > 0 && pageSize > 0)
                {
                    IEnumerable<CoursePrerequisiteResponse?>? responses = await _coursePrequistsService.GetPagedCoursePrequistsAsync(pageNumber, pageSize);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"Courses Prequists fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Page Number And Page Size Should be more than 0");


                await _logService.LogAsync($"No courses Prequists found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<CoursePrerequisiteResponse>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
