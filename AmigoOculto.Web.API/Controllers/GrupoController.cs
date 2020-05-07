using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoOculto.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Grupo")]
    public class GrupoController : Controller
    {
        private IGrupoService _grupoService;
        public GrupoController(IGrupoService grupoService)
        {
            _grupoService = grupoService;
        }
        // GET: api/Grupo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Grupo> grupos = await _grupoService.GetAll();
            var a = grupos.ToList();

            return Ok(a);
        }

        // GET: api/Grupo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Grupo grupo = await _grupoService.GetById(id);
            if (grupo == null)
                return Ok(new EmptyResult());

            return Ok(grupo);
        }
        
        // POST: api/Grupo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Grupo grupo)
        {
            try
            {
                await _grupoService.Add(grupo);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Não foi possivel inserir o novo registro.\nErro: {e.Message}");
            }                       
        }
        
        // PUT: api/Grupo/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Grupo grupo)
        {
            try
            {
                await _grupoService.Update(grupo);
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
                await _grupoService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Não foi possivel excluir o registro.\nErro: {e.Message}");
            }
        }
    }
}
