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
        private readonly IAcademicTermService _listService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public AcademicTermsController(IAcademicTermService listService, ILogService logService, IExceptionService exceptionService)
        {
            _listService = listService;
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
                AcademicTermResponse? response = await _listService.AddAcademicTermAsync(request);

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

        [HttpDelete("delete/{listID}", Name = "DeleteAcademicTermAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteAcademicTermAsync(int listID)
        {
            try
            {
                bool res = await _listService.DeleteAcademicTermAsync(listID);

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

        [HttpGet("get/{listID}", Name = "GetAcademicTermByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AcademicTermResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AcademicTermResponse>> GetAcademicTermByIDAsync(int listID)
        {
            try
            {
                AcademicTermResponse? response = await _listService.GetAcademicTermByIDAsync(listID);

                if (response != null)
                {
                    await _logService.LogAsync($"AcademicTerm with ID {listID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"AcademicTerm with ID {listID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"AcademicTerm with ID {listID} was not found.");
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
                IEnumerable<AcademicTermResponse>? responses = await _listService.GetPagedAcademicTermsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"AcademicTerms fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No lists found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No lists found on page {pageNumber}.");
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
