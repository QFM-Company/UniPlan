using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Services;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;
        private readonly IStudentTermService _studentTermService;
        private readonly IStudentCourseService _studentCourseService;

        public StudentsController(IStudentService studentService, ILogService logService, IExceptionService exceptionService, IStudentTermService studentTermService, IStudentCourseService studentCourseService)
        {
            _studentService = studentService;
            _logService = logService;
            _exceptionService = exceptionService;
            _studentTermService = studentTermService;
            _studentCourseService = studentCourseService;
        }

        [HttpPost("add", Name = "AddStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentResponse?>> AddStudentAsync(CreateStudentRequest request)
        {
            try
            {
                StudentResponse? response = await _studentService.AddStudentAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Student.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Student.");
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

        [HttpPut("update/{studentID}", Name = "UpdateStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentResponse?>> UpdateStudentAsync(UpdateStudentRequest request, int studentID)
        {
            try
            {
                bool res = await _studentService.UpdateStudentAsync(request, studentID);

                if (res)
                {
                    await _logService.LogAsync("Student updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to update Student.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Student.");
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

        [HttpDelete("delete/{studentID}", Name = "DeleteStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int studentID)
        {
            try
            {
                bool res = await _studentService.DeleteStudentAsync(studentID);

                if (res)
                {
                    await _logService.LogAsync("Student deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete Student.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Student.");
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

        [HttpGet("get/{studentID}", Name = "GetStudentByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentResponse>> GetStudentByIDAsync(int studentID)
        {
            try
            {
                StudentResponse? response = await _studentService.GetStudentByIDAsync(studentID);

                if (response != null)
                {
                    await _logService.LogAsync($"Student with ID {studentID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Student with ID {studentID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Student with ID {studentID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedStudentsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentResponse>?>> GetPagedStudentsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<StudentResponse>? responses = await _studentService.GetPagedStudentsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Students fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No students found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No students found on page {pageNumber}.");
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

        [HttpGet("{studentID}/terms", Name = "GetStudentTermsByStudenIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentTermResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentTermResponse>?>> GetStudentTermsByStudenIDAsync(int studentID)
        {
            try
            {
                if (studentID > 0)
                {
                    IEnumerable<StudentTermResponse>? responses = await _studentTermService.GetStudentTermsByStudentIDAsync(studentID);

                    if (responses != null && responses.Any())
                    {
                        await _logService.LogAsync($"Student Terms fetched successfully for studentID {studentID} with size {responses.Count()}.", ExternalServicesEnums.LogType.Info);
                        return Ok(responses);
                    }
                }
                else return BadRequest("Id Should be more than 0");

                await _logService.LogAsync($"No student Terms found.", ExternalServicesEnums.LogType.Warning);
                return Ok(new List<StudentTermResponse>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{studentID}/Courses", Name = "GetStudentCoursesByStudenIDAsync")]
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
