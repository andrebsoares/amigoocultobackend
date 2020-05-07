using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;

namespace AmigoOculto.Service.Services
{
    public class GrupoService: ServiceBase<Grupo>, IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;

        public GrupoService(IGrupoRepository grupoRepository) : base(grupoRepository)
        {
            _grupoRepository = grupoRepository;            
        }        
    }
}
