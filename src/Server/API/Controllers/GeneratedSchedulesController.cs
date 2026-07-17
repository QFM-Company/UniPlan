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
    [Route("api/generatedSchedules")]
    [ApiController]
    public class GeneratedSchedulesController : ControllerBase
    {
        private readonly IGeneratedScheduleService _scheduleService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public GeneratedSchedulesController(IGeneratedScheduleService scheduleService, ILogService logService, IExceptionService exceptionService)
        {
            _scheduleService = scheduleService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddGeneratedScheduleAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeneratedScheduleResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<GeneratedScheduleResponse?>> AddGeneratedScheduleAsync(GeneratedScheduleRequest request)
        {
            try
            {
                GeneratedScheduleResponse? response = await _scheduleService.AddGeneratedScheduleAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة الجدول المُولّد بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetGeneratedScheduleByWishListIDAsync", new { listID = response.WishListInfo.WishListID }, response);
                }

                await _logService.LogAsync("فشل إضافة الجدول المُولّد بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة الجدول المُولّد");
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
            catch (ConflictException conException)
            {
                return Conflict(conException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}