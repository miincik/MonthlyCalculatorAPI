using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Incomes;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : GenericBaseController<Salary,ISalaryService>
    {
        public SalaryController(ISalaryService salaryService) : base(salaryService)
        {
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int salaryId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(salaryId));
        }
        [HttpGet("getbytypeid")]
        public IActionResult GetTypeId(int typeId)
        {
            return base.GetResponseByResultSuccess(base._service.GetByTypeId(typeId));
        }
        [HttpGet("getbyhistoryid")]
        public IActionResult GetHistoryId(int historyId)
        {
            return base.GetResponseByResultSuccess(base._service.GetByHistoryId(historyId));
        }
        [HttpGet("getallbyasc")]
        public IActionResult GetAllSalaryAmountByASC(int amount)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllSalaryAmountByASC(amount));
        }
        [HttpGet("getallbydes")]
        public IActionResult GetAllSalaryAmountByDes(int amount)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllSalaryAmountByDes(amount));
        }
        [HttpGet("getallbytypename")]
        public IActionResult GetAllSalaryByTypeName(string typeName)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllSalaryByTypeName(typeName));
        }
        [HttpGet("getallbybetween")]
        public IActionResult GetAllSalaryBetweenValues(decimal minValue, decimal maxValue)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllSalaryBetweenValues(minValue,maxValue));
        }
    }
}
