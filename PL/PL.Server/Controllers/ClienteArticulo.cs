using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticulo : ControllerBase
    {
        private readonly BL.ClienteArticulo _clienteArticulo;

        public ClienteArticulo(BL.ClienteArticulo clienteArticulo)
        {
            _clienteArticulo = clienteArticulo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            EL.Result result = _clienteArticulo.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(int IdCliente, int IdArticulo)
        {
            EL.Result result = _clienteArticulo.Add(IdCliente, IdArticulo);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }
    }
}
