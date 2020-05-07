using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoOculto.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Usuario> usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Usuario amigo = await _usuarioService.GetById(id);
            if (amigo == null)
                return Ok(new EmptyResult());

            return Ok(amigo);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario amigo)
        {
            try
            {
                await _usuarioService.Add(amigo);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Não foi possivel inserir o novo registro.\nErro: {e.Message}");
            }                       
        }

        // PUT: api/Usuario/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Usuario amigo)
        {
            try
            {
                await _usuarioService.Update(amigo);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possivel editar o registro.\nErro: {e.Message}");
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            try
            {
                await _usuarioService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possivel excluir o registro.\nErro: {e.Message}");
            }
        }
    }
}
