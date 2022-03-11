using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceHistoryController : GenericBaseController<ExpenceHistory ,IExpenceHistoryService>
    {
        

        public ExpenceHistoryController(IExpenceHistoryService expenceHistoryService) : base(expenceHistoryService)
        {
            
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int expenceHistoryId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(expenceHistoryId));
        }
    }
}

