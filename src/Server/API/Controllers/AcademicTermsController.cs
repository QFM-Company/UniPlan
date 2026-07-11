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
    [Route("api/academicTerms")]
    [ApiController]
    public class AcademicTermsController : ControllerBase
    {
        private readonly IAcademicTermService _termService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public AcademicTermsController(IAcademicTermService termService, ILogService logService, IExceptionService exceptionService)
        {
            _termService = termService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost(Name = "AddAcademicTermAsync")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AcademicTermResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AcademicTermResponse?>> AddAcademicTermAsync(AcademicTermRequest request)
        {
            try
            {
                AcademicTermResponse? response = await _termService.AddAcademicTermAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم إضافة الفصل الدراسي بنجاح", ExternalServicesEnums.LogType.Info);
                    return CreatedAtRoute("GetAcademicTermByIDAsync", new { termID = response.TermID }, response);
                }

                await _logService.LogAsync("فشل إضافة الفصل الدراسي بسبب خطأ في الخادم", ExternalServicesEnums.LogType.Warning);
                return StatusCode(StatusCodes.Status500InternalServerError, "فشل إضافة الفصل الدراسي");
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

        [HttpDelete("{termID}", Name = "DeleteAcademicTermAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult> DeleteAcademicTermAsync(int termID)
        {
            try
            {
                bool res = await _termService.DeleteAcademicTermAsync(termID);

                if (res)
                {
                    await _logService.LogAsync("تم حذف الفصل الدراسي بنجاح", ExternalServicesEnums.LogType.Info);
                    return NoContent();
                }

                await _logService.LogAsync($"فشل الحذف لم يتم العثور على الفصل الدراسي بالمعرف {termID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على الفصل الدراسي بالمعرف {termID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("{termID}", Name = "GetAcademicTermByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AcademicTermResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AcademicTermResponse>> GetAcademicTermByIDAsync(int termID)
        {
            try
            {
                AcademicTermResponse? response = await _termService.GetAcademicTermByIDAsync(termID);

                if (response != null)
                {
                    await _logService.LogAsync($"تم جلب الفصل الدراسي بالمعرف {termID} بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"لم يتم العثور على الفصل الدراسي بالمعرف {termID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على الفصل الدراسي بالمعرف {termID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet(Name = "GetPagedAcademicTermsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AcademicTermResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<AcademicTermResponse>>> GetPagedAcademicTermsAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("يجب أن يكون رقم الصفحة وحجم الصفحة أكبر من 0");
            }

            try
            {
                IEnumerable<AcademicTermResponse>? responses = await _termService.GetPagedAcademicTermsAsync(pageNumber, pageSize);

                if (responses == null)
                {
                    responses = Enumerable.Empty<AcademicTermResponse>();
                }

                await _logService.LogAsync($"تم جلب الفصول الدراسية للصفحة {pageNumber} بحجم {pageSize} بنجاح", ExternalServicesEnums.LogType.Info);
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}