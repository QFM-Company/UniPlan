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
    [Route("api/courseOfferings")]
    [ApiController]
    public class CourseOfferingsController : ControllerBase
    {
        private readonly ICourseOfferingService _offeringService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public CourseOfferingsController(ICourseOfferingService offeringService, ILogService logService, IExceptionService exceptionService)
        {
            _offeringService = offeringService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddCourseOfferingAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseOfferingResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseOfferingResponse?>> AddCourseOfferingAsync(CreateCourseOfferingRequest request)
        {
            try
            {
                CourseOfferingResponse? response = await _offeringService.AddCourseOfferingAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("CourseOffering added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add CourseOffering.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add CourseOffering.");
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

        [HttpPut("update/{offeringID}", Name = "UpdateCourseOfferingAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdateCourseOfferingCourseOfferingAsync(UpdateCourseOfferingRequest request, int offeringID)
        {
            try
            {
                bool res = await _offeringService.UpdateCourseOfferingAsync(request, offeringID);

                if (res)
                {
                    await _logService.LogAsync("CourseOffering updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to update CourseOffering.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update CourseOffering.");
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

        [HttpDelete("delete/{offeringID}", Name = "DeleteCourseOfferingAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteCourseOfferingAsync(int offeringID)
        {
            try
            {
                bool res = await _offeringService.DeleteCourseOfferingAsync(offeringID);

                if (res)
                {
                    await _logService.LogAsync("CourseOffering deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete CourseOffering.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete CourseOffering.");
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

        [HttpGet("get/{offeringID}", Name = "GetCourseOfferingByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseOfferingResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<CourseOfferingResponse>> GetCourseOfferingByIDAsync(int offeringID)
        {
            try
            {
                CourseOfferingResponse? response = await _offeringService.GetCourseOfferingByIDAsync(offeringID);

                if (response != null)
                {
                    await _logService.LogAsync($"CourseOffering with ID {offeringID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"CourseOffering with ID {offeringID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"CourseOffering with ID {offeringID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedCourseOfferingsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CourseOfferingResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<CourseOfferingResponse>?>> GetPagedCourseOfferingsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<CourseOfferingResponse>? responses = await _offeringService.GetPagedCourseOfferingsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"CourseOfferings fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No offerings found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No offerings found on page {pageNumber}.");
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
