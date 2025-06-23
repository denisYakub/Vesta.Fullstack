using Microsoft.AspNetCore.Mvc;
using Vesta.Fullstack.Application.Services;
using Vesta.Fullstack.Server.Contracts;

namespace Vesta.Fullstack.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VestaController(OrderService orderService) : ControllerBase
    {
        [HttpPost("order")]
        public IActionResult CreateOrder([FromBody] OrderCreateRequest request)
        {
            orderService.CreateAndSaveNewOrder(
                request.SenderCity, request.SenderAddress,
                request.RecipientCity, request.RecipientAddress,
                request.CargoWeightKilograms, request.CargoCollectionDate
            );

            return new OkResult();
        }

        [HttpGet("order")]
        public IActionResult ReadOrders()
        {
            var result = orderService.GetAllOrders();

            return new OkObjectResult(result);
        }
    }
}
