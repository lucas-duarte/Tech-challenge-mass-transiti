using Core.Entidades;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Produtor.Controllers
{
    [ApiController]
    [Route("/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IBus _bus;

        public PedidoController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:fila"));
            await endpoint.Send(new Pedido(1, new Usuario(1, "Lucas Duarte Pereira", "lucasduarte@email.com")));
            return Ok();
        }
    }
}