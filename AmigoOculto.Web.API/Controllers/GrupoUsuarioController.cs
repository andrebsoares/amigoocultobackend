using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoOculto.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/GrupoUsuario")]
    public class GrupoUsuarioController : Controller
    {
        private IGrupoUsuarioService _grupoUsuarioService;
        public GrupoUsuarioController(IGrupoUsuarioService grupoUsuarioService)
        {
            _grupoUsuarioService = grupoUsuarioService;
        }
        // GET: api/GrupoUsuario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GrupoUsuario> grupoUsuarios = await _grupoUsuarioService.GetAll();
            return Ok(grupoUsuarios);
        }

        // GET: api/GrupoUsuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GrupoUsuario grupoUsuario = await _grupoUsuarioService.GetById(id);
            if (grupoUsuario == null)
                return Ok(new EmptyResult());

            return Ok(grupoUsuario);
        }

        // POST: api/GrupoUsuario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GrupoUsuario grupoUsuario)
        {
            try
            {
                await _grupoUsuarioService.Add(grupoUsuario);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Não foi possivel inserir o novo registro.\nErro: {e.Message}");
            }                       
        }

        // PUT: api/GrupoUsuario/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]GrupoUsuario grupoUsuario)
        {
            try
            {
                await _grupoUsuarioService.Update(grupoUsuario);
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
                await _grupoUsuarioService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possivel excluir o registro.\nErro: {e.Message}");
            }
        }
    }
}
