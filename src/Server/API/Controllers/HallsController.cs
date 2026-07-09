using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/halls")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly IHallService _hallService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public HallsController(IHallService hallService, ILogService logService, IExceptionService exceptionService)
        {
            _hallService = hallService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddHallAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HallResponse))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<HallResponse?>> AddHallAsync(CreateHallRequest request)
        {
            try
            {
                HallResponse? response = await _hallService.AddHallAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة القاعة بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetHallByIDAsync", new { hallID = response.HallID }, response);
                }

                await _logService.LogAsync("فشل إضافة القاعة بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة القاعة");
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

        [HttpPut("{hallID}", Name = "UpdateHallAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> UpdateHallHallAsync(int hallID, UpdateHallRequest request)
        {
            try
            {
                bool res = await _hallService.UpdateHallAsync(request, hallID);

                if (res)
                {
                    await _logService.LogAsync("تم تحديث القاعة بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على القاعة بالمعرف {hallID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على القاعة بالمعرف {hallID}");
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

        [HttpDelete("{hallID}", Name = "DeleteHallAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteHallAsync(int hallID)
        {
            try
            {
                bool res = await _hallService.DeleteHallAsync(hallID);

                if (res)
                {
                    await _logService.LogAsync("تم حذف القاعة بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على القاعة بالمعرف {hallID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على القاعة بالمعرف {hallID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{hallID}", Name = "GetHallByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HallResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<HallResponse>> GetHallByIDAsync(int hallID)
        {
            try
            {
                HallResponse? response = await _hallService.GetHallByIDAsync(hallID);

                if (response != null)
                {
                    await _logService.LogAsync($"تم جلب القاعة بالمعرف {hallID} بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"لم يتم العثور على القاعة بالمعرف {hallID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على القاعة بالمعرف {hallID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{pageNumber}/{pageSize}", Name = "GetPagedHallsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HallResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<HallResponse>>> GetPagedHallsAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("يجب أن يكون رقم الصفحة وحجم الصفحة أكبر من 0");
            }

            try
            {
                IEnumerable<HallResponse>? responses = await _hallService.GetPagedHallsAsync(pageNumber, pageSize);

                if (responses == null)
                {
                    responses = Enumerable.Empty<HallResponse>();
                }

                await _logService.LogAsync($"تم جلب القاعات للصفحة {pageNumber} بحجم {pageSize} بنجاح", ExternalServicesEnums.LogType.Info);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}