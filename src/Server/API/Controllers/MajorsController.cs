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
    [Route("api/majors")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorService _majorService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public MajorsController(IMajorService majorService, ILogService logService, IExceptionService exceptionService)
        {
            _majorService = majorService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddMajorAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MajorResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<MajorResponse?>> AddMajorAsync(MajorRequest request)
        {
            try
            {
                MajorResponse? response = await _majorService.AddMajorAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة التخصص بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetMajorByIDAsync", new { majorID = response.MajorID }, response);
                }

                await _logService.LogAsync("فشل إضافة التخصص بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة التخصص");
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

        [HttpPut("{majorID}", Name = "UpdateMajorAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> UpdateMajorAsync(int majorID, MajorRequest request)
        {
            try
            {
                bool res = await _majorService.UpdateMajorAsync(request, majorID);

                if (res)
                {
                    await _logService.LogAsync("تم تحديث التخصص بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على التخصص بالمعرف {majorID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على التخصص بالمعرف {majorID}");
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

        [HttpDelete("{majorID}", Name = "DeleteMajorAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteMajorAsync(int majorID)
        {
            try
            {
                bool res = await _majorService.DeleteMajorAsync(majorID);

                if (res)
                {
                    await _logService.LogAsync("تم حذف التخصص بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على التخصص بالمعرف {majorID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على التخصص بالمعرف {majorID}");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return Conflict(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{majorID}", Name = "GetMajorByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MajorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<MajorResponse>> GetMajorByIDAsync(int majorID)
        {
            try
            {
                MajorResponse? response = await _majorService.GetMajorByIDAsync(majorID);

                if (response != null)
                {
                    await _logService.LogAsync($"تم جلب التخصص بالمعرف {majorID} بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"لم يتم العثور على التخصص بالمعرف {majorID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على التخصص بالمعرف {majorID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet(Name = "GetPagedMajorsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MajorResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<MajorResponse>>> GetPagedMajorsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("يجب أن يكون رقم الصفحة وحجم الصفحة أكبر من 0");
            }

            try
            {
                IEnumerable<MajorResponse>? responses = await _majorService.GetPagedMajorsAsync(pageNumber, pageSize);

                if (responses == null)
                {
                    responses = Enumerable.Empty<MajorResponse>();
                }

                await _logService.LogAsync($"تم جلب التخصصات للصفحة {pageNumber} بحجم {pageSize} بنجاح", ExternalServicesEnums.LogType.Info);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}