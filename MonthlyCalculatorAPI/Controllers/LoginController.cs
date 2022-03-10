
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Services.Interfaces;
using MonthlyCalculatorAPI.Utilities.Security;
using static MonthlyCalculatorAPI.Utilities.Security.AppSettings;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        private IAccountService _accountService;

        public LoginController(ILoginService loginService, IAccountService accountService)
        {
            _loginService = loginService;
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginDTO model)
        {
            var response = _loginService.Authenticate(model);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
                
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
