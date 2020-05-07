using System.Collections.Generic;
using System.Threading.Tasks;
using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;

namespace AmigoOculto.Service.Services
{
    public class GrupoUsuarioService: ServiceBase<GrupoUsuario>, IGrupoUsuarioService
    {
        private readonly IGrupoUsuarioRepository _grupoUsuarioRepository;
        private readonly IGrupoService _grupoService;
        public GrupoUsuarioService(IGrupoUsuarioRepository grupoUsuarioRepository,
                                   IGrupoService grupoService) : base(grupoUsuarioRepository)
        {
            _grupoUsuarioRepository = grupoUsuarioRepository;
            _grupoService = grupoService;

        }

        public override async Task<IEnumerable<GrupoUsuario>> GetAll()
        {
            IEnumerable<GrupoUsuario> grupoUsuarios =  await _grupoUsuarioRepository.GetAll();
            foreach (var item in grupoUsuarios)
            {
                item.Grupo = await _grupoService.GetById(item.Grupo.Id);
            }
            return grupoUsuarios;
        }
        public override async Task<GrupoUsuario> GetById(int id)
        {
            return await GetById(id);
        }
    }
}
