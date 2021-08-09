using allopromoDataAccess.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace allopromo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly AccountService _accountService;
        public AccountController()
        {

        }
        public void  Login([FromBody] LoginModel loginModel)
        {
            /*var account = _signingManager.SignInAsync(loginModel.userName, loginModel.userPassword);
            if (account==null)
            {
                return NotFound(account);
            }
            return Ok(account)
            */
        }
        [HttpPost]
        public void Post([FromBody] CreateAccountModel accountModel)
        {
            //var createdAccount = _accountManager.CreateAccount(accountModel.userName);
            if (accountModel == null)
            {

            }
            //return Ok(accountModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public void Get([FromBody] LoginModel login)//IActionResult , HttpResponseMessage{
        {

        }
        [HttpPut]
        public void Put(string userName, string token)
        {
            //var token = JwtManager.ValidateToken(token);
            if (userName.Equals(token))
            {

            }
        }
        [HttpDelete]
        public void Delete(string userName, string Pwd)
        {

        }
    }
}
