using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cliente : ControllerBase
    {
        private readonly BL.Cliente _cliente;

        public Cliente(BL.Cliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            EL.Cliente cliente = new EL.Cliente();
            EL.Result result = _cliente.GetAll();
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int IdCliente)
        {
            EL.Cliente cliente = new EL.Cliente();
            EL.Result result = _cliente.GetById(IdCliente);
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
        public IActionResult Add(string Nombre, string ApellidoPaterno, string ApellidoMaterno)
        {

            EL.Result result = _cliente.Add(Nombre, ApellidoPaterno, ApellidoMaterno);
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Put([FromBody] EL.Cliente cliente)
        {
            EL.Result result = _cliente.Update(cliente);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int IdCliente)
        {
            EL.Result result = _cliente.Delete(IdCliente);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }
    }
}
