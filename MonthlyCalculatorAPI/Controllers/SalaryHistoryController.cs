using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryHistoryController : GenericBaseController<SalaryHistory, ISalaryHistoryService>
    {
        public SalaryHistoryController(ISalaryHistoryService salaryHistoryService) : base(salaryHistoryService)
        {
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll()); 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int salaryHistoryId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(salaryHistoryId));
        }
    }
}
