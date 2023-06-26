using Application.Dtos.Trabajadores;
using Application.Services.Abstractions;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Trabajadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : Controller
    {
        private readonly ITrabajadorService _trabajadorService;
        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }

        [HttpGet("ListarTrabajadores")]
        public async Task<IActionResult> ListarTrabajadores()
        {
            var obj = await _trabajadorService.ListaTrabajador();
            if(obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost("CrearTrabajador")]
        public async Task<IActionResult> CrearTrabajador([FromBody] TrabajadorFormDto request)
        {
            var obj = await _trabajadorService.CrearTrabajador(request);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("ActualizarTrabajador/{id}")]
        public async Task<IActionResult> ActualizarTrabajador(int id, [FromBody] TrabajadorFormDto request)
        {
            var response = await _trabajadorService.ActualizarTrabajador(id, request);

            if (response == null) return NotFound();

            return Ok(response);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var response = await _trabajadorService.BuscarPorId(id);
            if (response == null) return NotFound();

            return Ok(response);
        }

    }
}
