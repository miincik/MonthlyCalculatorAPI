using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceTypeController : GenericBaseController<ExpenceType, IExpenceTypeService>
    {
        public ExpenceTypeController(IExpenceTypeService expenceTypeService) : base(expenceTypeService)
        {
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int expenceTypeId)
        {
           return base.GetResponseByResultSuccess(base._service.GetById(expenceTypeId));
        }
    }
}

