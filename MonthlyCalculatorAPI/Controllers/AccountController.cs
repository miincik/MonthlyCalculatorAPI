﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : GenericBaseController<Account,IAccountService>
    {

        public AccountController(IAccountService accountService) : base(accountService)
        {

        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(id));
        }
    }
}
