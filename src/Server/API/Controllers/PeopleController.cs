using Business.DTOs.Requests;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public PeopleController(IPeopleService peopleService, ILogService logService, IExceptionService exceptionService)
        {
            _peopleService = peopleService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddPersonAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> AddPersonAsync(PersonRequest request)
        {
            try
            {
                bool res = await _peopleService.AddPersonAsync(request);

                if (res)
                {
                    await _logService.LogAsync("Person added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to add person.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add person.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
