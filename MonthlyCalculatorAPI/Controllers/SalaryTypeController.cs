using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryTypeController : GenericBaseController<SalaryType, ISalaryTypeService>
    {
        public SalaryTypeController(ISalaryTypeService salaryTypeService) : base(salaryTypeService)
        {
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll()); 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int salaryTypeId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(salaryTypeId));
        }
    }
}
