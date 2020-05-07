using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Models;
using AmigoOculto.Repository.Context;

namespace AmigoOculto.Repository.Repositories
{
    public class GrupoUsuarioRepository : RepositoryBase<GrupoUsuario>, IGrupoUsuarioRepository
    {
        public GrupoUsuarioRepository(AmigoOcultoContext context) : base(context)
        {
        }
    }
}
