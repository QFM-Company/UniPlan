using Business.DTOs.Requests;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Periods")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private IPeriodService _periodService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public PeriodController(IPeriodService periodService, ILogService logService, IExceptionService exceptionService)
        {
            _periodService = periodService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddPeriodAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> AddPeriodAsync(PeriodRequest request)
        {
            try
            {
                bool res = await _periodService.AddPeriodAsync(request);

                if (res)
                {
                    await _logService.LogAsync("Period added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to add period.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add period.");
            }
            catch (Exception ex)
            {
                await _logService.LogAsync("error" , ExternalServicesEnums.LogType.Error);
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

    }
}
