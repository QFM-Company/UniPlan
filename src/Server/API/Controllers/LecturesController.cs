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
    [Route("api/lectures")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public LecturesController(ILectureService lectureService, ILogService logService, IExceptionService exceptionService)
        {
            _lectureService = lectureService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddLectureAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LectureResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<LectureResponse?>> AddLectureAsync(LectureRequest request)
        {
            try
            {
                LectureResponse? response = await _lectureService.AddLectureAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة المحاضرة بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetLectureByIDAsync", new { lectureID = response.LectureID }, response);
                }

                await _logService.LogAsync("فشل إضافة المحاضرة بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة المحاضرة");
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

        [HttpPut("{lectureID}", Name = "UpdateLectureAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> UpdateLectureAsync(int lectureID, LectureRequest request)
        {
            try
            {
                bool res = await _lectureService.UpdateLectureAsync(request, lectureID);

                if (res)
                {
                    await _logService.LogAsync("تم تحديث المحاضرة بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على المحاضرة بالمعرف {lectureID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على المحاضرة بالمعرف {lectureID}");
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

        [HttpDelete("{lectureID}", Name = "DeleteLectureAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteLectureAsync(int lectureID)
        {
            try
            {
                bool res = await _lectureService.DeleteLectureAsync(lectureID);

                if (res)
                {
                    await _logService.LogAsync("تم حذف المحاضرة بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"لم يتم العثور على المحاضرة بالمعرف {lectureID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على المحاضرة بالمعرف {lectureID}");
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

        [HttpGet("{lectureID}", Name = "GetLectureByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LectureResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<LectureResponse>> GetLectureByIDAsync(int lectureID)
        {
            try
            {
                LectureResponse? response = await _lectureService.GetLectureByIDAsync(lectureID);

                if (response != null)
                {
                    await _logService.LogAsync($"تم جلب المحاضرة بالمعرف {lectureID} بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"لم يتم العثور على المحاضرة بالمعرف {lectureID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على المحاضرة بالمعرف {lectureID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet(Name = "GetPagedLecturesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LectureResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<LectureResponse>>> GetPagedLecturesAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("يجب أن يكون رقم الصفحة وحجم الصفحة أكبر من 0");
            }

            try
            {
                IEnumerable<LectureResponse>? responses = await _lectureService.GetPagedLecturesAsync(pageNumber, pageSize);

                if (responses == null)
                {
                    responses = Enumerable.Empty<LectureResponse>();
                }

                await _logService.LogAsync($"تم جلب المحاضرات للصفحة {pageNumber} بحجم {pageSize} بنجاح", ExternalServicesEnums.LogType.Info);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}