using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {

                var result = BL.Usuario.GetAll(new ML.Usuario());

                if (result.Correct)
                {
                    return Ok(result.Objects);
                }
                else
                {
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            var result = BL.Usuario.Add(usuario);
            if (result.Correct)
            {
                return Ok("Usuario agregado correctamente");
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpGet("GetById/{IdUsuario}")]
        public IActionResult GetById(int IdUsuario)
        {
            var result = BL.Usuario.GetById(IdUsuario);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ML.Usuario usuario)
        {
            var result = BL.Usuario.Update(usuario);
            if (result.Correct)
            {
                return Ok("Usuario actualizado correctamente");
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpDelete("Delete/{IdUsuario}")]
        public IActionResult Delete(int IdUsuario)
        {
            var result = BL.Usuario.Delete(IdUsuario);
            if (result.Correct)
            {
                return Ok("Usuario eliminado correctamente");
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
