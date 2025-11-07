using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Articulo : ControllerBase
    {
        private readonly BL.Articulo _articulo;

        public Articulo(BL.Articulo articulo)
        {
            _articulo = articulo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
           
            EL.Result result = _articulo.GetAll();
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int IdArticulo)
        {
            EL.Articulo articulo = new EL.Articulo();
            EL.Result result = _articulo.GetById(IdArticulo);
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] EL.Articulo articulo)
        {

            EL.Result result = _articulo.Add(articulo);
            if (result.Correct)
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Put([FromBody] EL.Articulo articulo)
        {
            EL.Result result = _articulo.Update(articulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int IdArticulo)
        {
            EL.Result result = _articulo.Delete(IdArticulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
