using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/academicTerms")]
    [ApiController]
    public class AcademicTermsController : ControllerBase
    {
        private IAcademicTermService _termService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public AcademicTermsController(IAcademicTermService termService, ILogService logService, IExceptionService exceptionService)
        {
            _termService = termService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddAcademicTermAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AcademicTermResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AcademicTermResponse?>> AddAcademicTermAsync(AcademicTermRequest request)
        {
            try
            {
                AcademicTermResponse? response = await _termService.AddAcademicTermAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("AcademicTerm added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add AcademicTerm.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add AcademicTerm.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpDelete("delete/{termID}", Name = "DeleteAcademicTermAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteAcademicTermAsync(int termID)
        {
            try
            {
                bool res = await _termService.DeleteAcademicTermAsync(termID);

                if (res)
                {
                    await _logService.LogAsync("AcademicTerm deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete AcademicTerm.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete AcademicTerm.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("get/{termID}", Name = "GetAcademicTermByIDAsync")]
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
                    await _logService.LogAsync($"AcademicTerm with ID {termID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"AcademicTerm with ID {termID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"AcademicTerm with ID {termID} was not found.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedAcademicTermsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AcademicTermResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<AcademicTermResponse>?>> GetPagedAcademicTermsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<AcademicTermResponse>? responses = await _termService.GetPagedAcademicTermsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"AcademicTerms fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No terms found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No terms found on page {pageNumber}.");
            }
            catch (SqlException sqlException) when (sqlException.Number > 50000)
            {
                return BadRequest(_exceptionService.GetExceptionMessage(sqlException));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}
