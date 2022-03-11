
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Services.Interfaces;


namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : GenericBaseController<Expence, IExpenceService>
    {
        

        public ExpenceController(IExpenceService expenceService) :base(expenceService)
        {
            
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return base.GetResponseByResultSuccess(base._service.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int expenceId)
        {
            return base.GetResponseByResultSuccess(base._service.GetById(expenceId));
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
        public IActionResult GetAllExpenceAmountByASC(int amount)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllExpenceAmountByASC(amount));
        }
        [HttpGet("getallbydes")]
        public IActionResult GetAllExpenceAmountByDes(int amount)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllExpenceAmountByDes(amount));
        }
        [HttpGet("getallbytypename")]
        public IActionResult GetAllExpenceByTypeName(string typeName)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllExpenceByTypeName(typeName));
        }
        [HttpGet("getallbybetween")]
        public IActionResult GetAllExpenceBetweenValues(decimal minValue,decimal maxValue)
        {
            return base.GetResponseByResultSuccess(base._service.GetAllExpenceBetweenValues(minValue,maxValue));
        }

    }
}
    
