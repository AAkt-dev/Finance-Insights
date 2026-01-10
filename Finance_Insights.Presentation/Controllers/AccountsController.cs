using Finance_Insights.Service_Contracts;
using Finance_Insights.Shared.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace Finance_Insights.Presentation.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AccountsController:ControllerBase
    {
        private readonly IServiceManager _service;
        public AccountsController(IServiceManager service)
        {
            this._service=service;
        }
        [HttpGet("{accountId:guid}",Name ="GetAccount")]
        public IActionResult GetAccountByAccountId(Guid accountId)
        {
            var account=_service.accountService.GetAccountByAccountId(accountId,trackChanges:false);
            return Ok(account);
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetAccountByUserId(string userId)
        {
            var account=_service.accountService.GetAccountByUserId(userId,trackChanges:false);
            return Ok(account); 
        }
        [HttpGet]
        public IActionResult GetAllAccount()
        {
            var accounts=_service.accountService.GetAllAccounts(trackChanges:false);
            return Ok(accounts);
        }
        [HttpPost]
        public IActionResult CreateAccount([FromBody]AccountForCreationDto accountForCreation)
        {
            if (accountForCreation == null)
            {
                return BadRequest("AccountForCreationDto is null");
            }
            var accountToReturn = _service.accountService.CreateAccount(accountForCreation, trackChanges: false);
            return CreatedAtRoute("GetAccount", new { accountId = accountToReturn.AccountId},accountToReturn);
        }
        [HttpDelete("{accountId:guid}")]
        public IActionResult DeleteAccount(Guid accountId)
        {
            _service.accountService.DeleteAccount(accountId,trackChanges:false);
            return NoContent();
        }
        [HttpPatch("user/{userId}")]
        public IActionResult UpdateAccount(string userId, [FromBody]JsonPatchDocument<AccountForUpdateDto> document)
        {
            if (document == null)
            {
                return BadRequest("Patch Documnet object sent from the client is null");
            }
            var result=_service.accountService.GetAccountforPatch(userId, trackChanges: true);
            document.ApplyTo(result.accountToPatch);
            _service.accountService.SaveChangesForPatch(result.accountToPatch, result.accountEntity);
            return NoContent();
        }
    }
}
