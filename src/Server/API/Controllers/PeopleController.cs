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
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public PeopleController(IPeopleService peopleService, ILogService logService, IExceptionService exceptionService)
        {
            _peopleService = peopleService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddPersonAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<PersonResponse?>> AddPersonAsync(PersonRequest request)
        {
            try
            {
                PersonResponse? response = await _peopleService.AddPersonAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة الشخص بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetPersonByIDAsync", new { personID = response.PersonID }, response);
                }

                await _logService.LogAsync("فشل إضافة الشخص بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة الشخص");
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
    }
}