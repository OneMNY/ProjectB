using Microsoft.AspNetCore.Mvc;
using BusinessLogicLibrary.Model;
using BusinessLogicLibrary.Application;
using System.Xml.Serialization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderParser _parser;

        public OrderController(ILogger<OrderController> logger, IOrderParser parser)
        {
            _logger = logger;
            _parser = parser;
        }


        [HttpPost()]
        [Route("CalculateTotalShippedQty")]
        [Consumes("application/xml")]
        public async Task<IActionResult> CalculateTotalShippedQty([FromBody] OrderWrapperXmlDto dto)
        {
            var model = _parser.FromDtoToModel(dto);

            return Ok(model.Details.Sum(x => x.ShippedQty).ToString());
        }
    }
}