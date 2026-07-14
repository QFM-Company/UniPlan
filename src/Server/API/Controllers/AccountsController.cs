using Business.DTOs.Requests;
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
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogService _logService;
        private readonly IExceptionService _exceptionService;

        public AccountsController(IAccountService accountService, ILogService logService, IExceptionService exceptionService)
        {
            _accountService = accountService;
            _logService = logService;
            _exceptionService = exceptionService;
        }

        [HttpPost("login", Name = "LoginAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AccountResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<AccountResponse?>> LoginAsync(LoginRequest request)
        {
            try
            {
                AccountResponse? response = await _accountService.LoginAsync(request);

                if (response != null)
                {
                    await _logService.LogAsync("تم تسجيل دخول الحساب بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync("فشل تسجيل دخول الحساب", ExternalServicesEnums.LogType.Warning);
                return Unauthorized("فشل تسجيل دخول الحساب");
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

        [HttpPut("{accountID}/updatePassword", Name = "UpdatePasswordAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<ActionResult<bool>> UpdatePasswordAsync(ChangePasswordRequest request, int accountID)
        {
            try
            {
                bool res = await _accountService.UpdatePasswordAsync(request, accountID);

                if (res)
                {
                    await _logService.LogAsync("تم تحديث كلمة المرور بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(res);
                }

                await _logService.LogAsync($"لم يتم العثور على الحساب بالمعرف {accountID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على الحساب بالمعرف {accountID}");
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


        [HttpGet("{accountID}", Name = "GetAccountByIDAsync")]
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
                    await _logService.LogAsync($"تم جلب الحساب بالمعرف {accountID} بنجاح", ExternalServicesEnums.LogType.Info);
                    return Ok(response);
                }

                await _logService.LogAsync($"لم يتم العثور على الحساب بالمعرف {accountID}", ExternalServicesEnums.LogType.Warning);
                return NotFound($"لم يتم العثور على الحساب بالمعرف {accountID}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, _exceptionService.GetExceptionMessage(ex));
            }
        }
    }
}