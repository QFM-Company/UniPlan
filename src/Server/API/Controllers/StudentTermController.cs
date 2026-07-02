using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/studentTerms")]
    [ApiController]
    public class StudentTermController : ControllerBase
    {
        private IStudentTermService _studentTermService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public StudentTermController(IStudentTermService studentTermService, ILogService logService, IExceptionService exceptionService)
        {
            _studentTermService = studentTermService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddStudentTermAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentTermResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentTermResponse?>> AddStudentTermAsync(StudentTermRequest request)
        {
            try
            {
                StudentTermResponse? response = await _studentTermService.AddStudentTermAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student Term added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Student Term.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Student Term.");
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

        [HttpGet("get/{studentTermID}", Name = "GetStudentTermByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentTermResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentTermResponse>> GetStudentTermByIDAsync(int studentTermID)
        {
            try
            {
                StudentTermResponse? response = await _studentTermService.GetStudentTermByIDAsync(studentTermID);

                if (response != null)
                {
                    await _logService.LogAsync($"Student Term with ID {studentTermID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Student Term with ID {studentTermID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Student Term with ID {studentTermID} was not found.");
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

        [HttpGet("get/{StudentID}/", Name = "GetStudentTermsByStudenIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentTermResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<StudentTermResponse>?>> GetStudentTermsByStudenIDAsync(int studentID)
        {
            try
            {
                IEnumerable<StudentTermResponse>? responses = await _studentTermService.GetStudentTermsByStudentIDAsync(studentID);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Student Terms fetched successfully for studentID {studentID} with size {responses.Count()}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No student Terms found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No student Terms found on page.");
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
