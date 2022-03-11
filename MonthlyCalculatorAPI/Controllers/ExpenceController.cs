using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonthlyCalculatorAPI.Models.Entities.Expences;
using MonthlyCalculatorAPI.Services.Interfaces;

namespace MonthlyCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : ControllerBase
    {
        private readonly IExpenceService _expenceService;

        public ExpenceController(IExpenceService expenceService)
        {
            _expenceService = expenceService;
        }

        [HttpPost("add")]
        public IActionResult Add(Expence expence)
        {
            var result = _expenceService.Add(expence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("delete")]
        public IActionResult Delete(Expence expence)
        {
            var result = _expenceService.Delete(expence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(Expence expence)
        {
            var result = _expenceService.Update(expence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _expenceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int expenceId)
        {
            var result = _expenceService.GetById(expenceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbytypeid")]
        public IActionResult GetTypeId(int typeId)
        {
            var result = _expenceService.GetByTypeId(typeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyhistoryid")]
        public IActionResult GetHistoryId(int historyId)
        {
            var result = _expenceService.GetByHistoryId(historyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbyasc")]
        public IActionResult GetAllExpenceAmountByASC(int amount)
        {
            var result = _expenceService.GetAllExpenceAmountByASC(amount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbydes")]
        public IActionResult GetAllExpenceAmountByDes(int amount)
        {
            var result = _expenceService.GetAllExpenceAmountByDes(amount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbytypename")]
        public IActionResult GetAllExpenceByTypeName(string typeName)
        {
            var result = _expenceService.GetAllExpenceByTypeName(typeName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbybetween")]
        public IActionResult GetAllExpenceBetweenValues(decimal minValue,decimal maxValue)
        {
            var result = _expenceService.GetAllExpenceBetweenValues(minValue, maxValue);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
    
