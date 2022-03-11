using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _accountService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Account account)
        {
            var result = _accountService.Add(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("delete")]
        public IActionResult Delete(Account account)
        {
            var result = _accountService.Delete(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Account account)
        {
            var result = _accountService.Update(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
