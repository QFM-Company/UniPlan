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
    [Route("api/lectures")]
    [ApiController]
    public class LecturesController : ControllerBase
    {
        private ILectureService _lectureService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public LecturesController(ILectureService lectureService, ILogService logService, IExceptionService exceptionService)
        {
            _lectureService = lectureService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("add", Name = "AddLectureAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LectureResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<LectureResponse?>> AddLectureAsync(LectureRequest request)
        {
            try
            {
                LectureResponse? response = await _lectureService.AddLectureAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Lecture added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Lecture.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Lecture.");
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

        [HttpPut("update/{lectureID}", Name = "UpdateLectureAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LectureResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<LectureResponse?>> UpdateLectureLectureAsync(LectureRequest request, int lectureID)
        {
            try
            {
                LectureResponse? response = await _lectureService.UpdateLectureAsync(request, lectureID);

                if (response != null)
                {
                    await _logService.LogAsync("Lecture updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to update Lecture.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Lecture.");
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

        [HttpDelete("delete/{lectureID}", Name = "DeleteLectureAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteLectureAsync(int lectureID)
        {
            try
            {
                bool res = await _lectureService.DeleteLectureAsync(lectureID);

                if (res)
                {
                    await _logService.LogAsync("Lecture deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete Lecture.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Lecture.");
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

        [HttpGet("get/{lectureID}", Name = "GetLectureByIDAsync")]
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
                    await _logService.LogAsync($"Lecture with ID {lectureID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Lecture with ID {lectureID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Lecture with ID {lectureID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedLecturesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LectureResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<LectureResponse>?>> GetPagedLecturesAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<LectureResponse>? responses = await _lectureService.GetPagedLecturesAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Lectures fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No lectures found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No lectures found on page {pageNumber}.");
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
