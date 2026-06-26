using Business.DTOs.Requests;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Enums;
using Core.Interfaces.ExternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountService _accountService;
        private ILogService _logService;
        private IExceptionService _exceptionService;

        public AccountsController(IAccountService accountService, ILogService logService, IExceptionService exceptionService)
        {
            _accountService = accountService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("login", Name = "LoginAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AccountResponse?>> LoginAsync(LoginRequest request)
        {
            try
            {
                AccountResponse? response = await _accountService.LoginAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("Account login successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("Failed to login Account.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to login Account");
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

        [HttpPut("updatePassword/{accountID}", Name = "UpdatePasswordAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdatePasswordAsync(ChangePasswordRequest request, int accountID)
        {
            try
            {
                bool res = await _accountService.UpdatePasswordAsync(request, accountID);

                if (res)
                {
                    await _logService.LogAsync("Account updated successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync("Failed to update Account.", ExternalServicesEnums.LogType.Warning);
                return BadRequest("Failed to update Account.");
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


        [HttpGet("get/{accountID}", Name = "GetAccountByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AccountResponse>> GetAccountByIDAsync(int accountID)
        {
            try
            {
                AccountResponse? response = await _accountService.GetAccountByIDAsync(accountID);

                if (response != null)
                {
                    await _logService.LogAsync($"Account with ID {accountID} fetched successfully.", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"Account with ID {accountID} was not found.", ExternalServicesEnums.LogType.Warning);
                return NotFound($"Account with ID {accountID} was not found.");
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
