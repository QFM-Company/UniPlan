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

        [HttpPost("add", Name = "AddHallAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HallResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<HallResponse?>> AddHallAsync(CreateHallRequest request)
        {
            try
            {
                HallResponse? response = await _hallService.AddHallAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Hall added successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to add Hall.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to add Hall.");
            }
            catch(SqlException sqlException) when(sqlException.Number > 50000) 
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

        [HttpPut("update/{hallID}", Name = "UpdateHallAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdateHallHallAsync(UpdateHallRequest request, int hallID)
        {
            try
            {
                bool res = await _hallService.UpdateHallAsync(request, hallID);

                if (res)
                {
                    await _logService.LogAsync("Hall updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to update Hall.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Hall.");
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

        [HttpDelete("delete/{hallID}", Name = "DeleteHallAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> DeleteHallAsync(int hallID)
        {
            try
            {
                bool res = await _hallService.DeleteHallAsync(hallID);

                if (res)
                {
                    await _logService.LogAsync("Hall deleted successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to delete Hall.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to delete Hall.");
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

        [HttpGet("get/{hallID}", Name = "GetHallByIDAsync")]
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
                    await _logService.LogAsync($"Hall with ID {hallID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Hall with ID {hallID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Hall with ID {hallID} was not found.");
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

        [HttpGet("get/{pageNumber}/{pageSize}", Name = "GetPagedHallsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HallResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<HallResponse>?>> GetPagedHallsAsync(int pageNumber, int pageSize)
        {
            try
            {
                IEnumerable<HallResponse>? responses = await _hallService.GetPagedHallsAsync(pageNumber, pageSize);

                if (responses != null && responses.Any())
                {
                    await _logService.LogAsync($"Halls fetched successfully for page {pageNumber} with size {pageSize}.", ExternalServicesEnums.LogType.Info);
                    return Ok(responses);
                }

                await _logService.LogAsync($"No halls found on page {pageNumber}.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"No halls found on page {pageNumber}.");
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
