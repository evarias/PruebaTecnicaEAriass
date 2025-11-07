using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tienda : ControllerBase
    {
        private readonly BL.Tienda _tienda;

        public Tienda(BL.Tienda tienda)
        {
            _tienda = tienda;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            EL.Tienda articulo = new EL.Tienda();
            EL.Result result = _tienda.GetAll();
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
        public IActionResult GetById(int IdTienda)
        {
            EL.Tienda articulo = new EL.Tienda();
            EL.Result result = _tienda.GetById(IdTienda);
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
        public IActionResult Add(string sucursal)
        {

            EL.Result result = _tienda.Add(sucursal);
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
        public IActionResult Put([FromBody] EL.Tienda tienda)
        {
            EL.Result result = _tienda.Update(tienda);

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
        public IActionResult Delete(int IdTienda)
        {
            EL.Result result = _tienda.Delete(IdTienda);

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
