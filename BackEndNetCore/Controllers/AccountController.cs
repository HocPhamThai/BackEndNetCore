using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BackEndNetCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost("AccountLogin")]
        public async Task<IActionResult> AccountLogin(AccountRequestData accountRequestData)
        {
            var returnData = new ReturnData();
            try
            {
                returnData = await _accountServices.AccountLogin(accountRequestData);
                return Ok(returnData);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
