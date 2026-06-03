using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Services;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public StudentsController(IStudentService studentService, ILogService logService, IExceptionService exceptionService)
        {
            _studentService = studentService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentProfileResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentProfileResponse?>> AddStudentAsync(CreateStudentRequest request)
        {
            try
            {
                StudentProfileResponse? response = await _studentService.AddStudentAsync(request);

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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpPut("update", Name = "UpdateStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentProfileResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentProfileResponse?>> UpdateStudentAsync(UpdateStudentRequest request)
        {
            try
            {
                StudentProfileResponse? response = await _studentService.UpdateStudentAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to update Student.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Student.");
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentProfileResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentProfileResponse>> GetStudentByIDAsync(int studentID)
        {
            try
            {
                StudentProfileResponse? response = await _studentService.GetStudentByIDAsync(studentID);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentProfileResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentProfileResponse>?>> GetPagedStudentsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<StudentProfileResponse>? responses = await _studentService.GetPagedStudentsAsync(pageNumber, pageSize);

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
    }
}
