using Banking.Service;
using Banking.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Banking.WebApi.Extensions;

namespace Banking.WebApi.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        [HttpPost(template: "")]
        public async Task<IActionResult> PostAccountAsync([FromBody] CreateAccountDto createAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newAccount = await _accountService.CreateAccountAsync(createAccountDto.ToCreateAccount());

            return Ok(newAccount.ToCreateAccountResultDto());
        }

        [HttpPost(template: "deposit")]
        public IActionResult Deposit([FromBody] DepositAccountDto depositAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _accountService.DepositAccount(depositAccountDto.ToDepositAccount());

            return Ok(result.ToDepositAccountResultDto());
        }

        [HttpPost(template: "transfer")]
        public IActionResult Transfer([FromBody] TransferAccountDto transferAccountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _accountService.TransferAccount(transferAccountDto.ToTransferAccount());

            return Ok(result.ToTransferAccountResultDto());
        }
    }
}
