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

        [HttpPost("add", Name = "AddPersonAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<PersonResponse?>> AddPersonAsync(PersonRequest request)
        {
            try
            {
                PersonResponse? response = await _peopleService.AddPersonAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Person added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add person.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add person.");
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
    }
}
