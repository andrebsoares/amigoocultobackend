 using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Interfaces.Services;
using AmigoOculto.Domain.Models;

namespace AmigoOculto.Service.Services
{
    public class UsuarioService: ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _amigoRepository;
        public UsuarioService(IUsuarioRepository amigoRepository): base(amigoRepository)
        {
            _amigoRepository = amigoRepository;

        }
    }
}
