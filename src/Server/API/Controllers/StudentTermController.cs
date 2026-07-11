using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/studentTerms")]
    [ApiController]
    public class StudentTermController : ControllerBase
    {
        private readonly IWishListService _listService;
        private IStudentTermService _studentTermService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public StudentTermController(IStudentTermService studentTermService, ILogService logService, IExceptionService exceptionService, IWishListService listService)
        {
            _studentTermService = studentTermService;
            _logService = logService;
            _exceptionService = exceptionService;
            _listService = listService;
        }

        [HttpPost(Name = "AddStudentTermAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentTermResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<StudentTermResponse?>> AddStudentTermAsync(StudentTermRequest request)
        {
            try
            {
                StudentTermResponse? response = await _studentTermService.AddStudentTermAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Student Term added successfully.", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetStudentTermByIDAsync", new { studentTermID = response.RegistrationID}, response);
                }

                await _logService.LogAsync("Failed to add Student Term.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Student Term.");
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

        [HttpGet("{studentTermID}", Name = "GetStudentTermByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentTermResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<StudentTermResponse>> GetStudentTermByIDAsync(int studentTermID)
        {
            try
            {
                if (studentTermID > 0)
                {
                    StudentTermResponse? response = await _studentTermService.GetStudentTermByIDAsync(studentTermID);

                    if (response != null)
                    {
                        await _logService.LogAsync($"Student Term with ID {studentTermID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                        return Ok(response);
                    }
                }
                else return BadRequest("Id Should be more than 0");


                await _logService.LogAsync($"Student Term with ID {studentTermID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Student Term with ID {studentTermID} was not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{registrationID}/wishLists", Name = "GetWishListsByRegistrationIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WishListResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<WishListResponse>>> GetWishListsByRegistrationIDAsync(int registrationID)
        {
            if (registrationID <= 0)
            {
                return BadRequest("يجب أن يكون معرف التسجيل أكبر من 0");
            }

            try
            {
                IEnumerable<WishListResponse>? responses = await _listService.GetWishListsByRegistrationIDAsync(registrationID);

                if (responses == null)
                {
                    responses = Enumerable.Empty<WishListResponse>();
                }

                await _logService.LogAsync($"تم جلب قوائم الرغبات لمعرف التسجيل {registrationID} بنجاح", ExternalServicesEnums.LogType.Info);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
