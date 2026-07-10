using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/studentCourses")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private IStudentCourseService _studentCourseService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public StudentCourseController(IStudentCourseService studentCourseService, ILogService logService, IExceptionService exceptionService)
        {
            _studentCourseService = studentCourseService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddStudentCourseAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentCourseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentCourseResponse?>> AddStudentCourseAsync(CreateStudentCourseRequest request)
        {
            try
            {
                StudentCourseResponse? response = await _studentCourseService.AddStudentCourseAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student Course added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetStudentCourseByIDAsync", new { studentCourseID = response.EnrolmentID} , response);
                }

                await _logService.LogAsync("Failed to add Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Student Course.");
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

        [HttpPut("update/{studentCourseID}", Name = "UpdateStudentCourseAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> UpdateStudentCourseAsync(UpdateStudentCourseRequest request, int studentCourseID)
        {
            try
            {
                if (studentCourseID > 0)
                {
                    bool res = await _studentCourseService.UpdateStudentCourseAsync(request, studentCourseID);

                    if (res)
                    {
                        await _logService.LogAsync("Student Course updated successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }
                await _logService.LogAsync("Failed to update Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Student Course.");
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

        [HttpDelete("delete/{studentCourseID}", Name = "DeleteStudentCourseAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteStudentCourseAsync(int studentCourseID)
        {
            try
            {
                if (studentCourseID > 0)
                {
                    bool res = await _studentCourseService.DeleteStudentCourseAsync(studentCourseID);

                    if (res)
                    {
                        await _logService.LogAsync("Student Course deleted successfully.", ExternalServicesEnums.LogType.Info);
                        return NoContent();
                    }
                }
                await _logService.LogAsync("Failed to delete Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Student Course.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("get/{studentCourseID}", Name = "GetStudentCourseByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCourseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentCourseResponse>> GetStudentCourseByIDAsync(int studentCourseID)
        {
            try
            {
                if (studentCourseID > 0)
                {
                    StudentCourseResponse? response = await _studentCourseService.GetStudentCourseByIDAsync(studentCourseID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"Student Course with ID {studentCourseID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"Student Course with ID {studentCourseID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Student Course with ID {studentCourseID} was not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("student/{studentID}/", Name = "GetStudentCoursesByStudenIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentCourseResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentCourseResponse>?>> GetStudentCoursesByStudenIDAsync(int studentID)
        {
            try
            {
                if (studentID > 0)
                {
                    IEnumerable<StudentCourseResponse>? responses = await _studentCourseService.GetStudentCoursesByStudentIDAsync(studentID);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"Student Courses fetched successfully for studentID {studentID} with size {responses.Count()}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"No student Courses found.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<StudentCourseResponse>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
