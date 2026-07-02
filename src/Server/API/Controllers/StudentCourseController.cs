using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCourseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentCourseResponse?>> AddStudentCourseAsync(CreateStudentCourseRequest request)
        {
            try
            {
                StudentCourseResponse? response = await _studentCourseService.AddStudentCourseAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student Course added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Student Course.");
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

        [HttpPut("update/{studentCourseID}", Name = "UpdateStudentCourseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdateStudentCourseAsync(UpdateStudentCourseRequest request, int studentCourseID)
        {
            try
            {
                bool res = await _studentCourseService.UpdateStudentCourseAsync(request, studentCourseID);

                if (res)
                {
                    await _logService.LogAsync("Student Course updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to update Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Student Course.");
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

        [HttpDelete("delete/{studentCourseID}", Name = "DeleteStudentCourseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteStudentCourseAsync(int studentCourseID)
        {
            try
            {
                bool res = await _studentCourseService.DeleteStudentCourseAsync(studentCourseID);

                if (res)
                {
                    await _logService.LogAsync("Student Course deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete Student Course.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Student Course.");
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

        [HttpGet("get/{studentCourseID}", Name = "GetStudentCourseByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCourseResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentCourseResponse>> GetStudentCourseByIDAsync(int studentCourseID)
        {
            try
            {
                StudentCourseResponse? response = await _studentCourseService.GetStudentCourseByIDAsync(studentCourseID);

                if (response != null)
                {
                    await _logService.LogAsync($"Student Course with ID {studentCourseID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Student Course with ID {studentCourseID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Student Course with ID {studentCourseID} was not found.");
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

        [HttpGet("get/{StudentID}/", Name = "GetStudentCoursesByStudenIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentCourseResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentCourseResponse>?>> GetStudentCoursesByStudenIDAsync(int studentID)
        {
            try
            {
                IEnumerable<StudentCourseResponse>? responses = await _studentCourseService.GetStudentCoursesByStudentIDAsync(studentID);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Student Courses fetched successfully for studentID {studentID} with size {responses.Count()}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No student Courses found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No student Courses found on page.");
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
