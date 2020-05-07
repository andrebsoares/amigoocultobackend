using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Models;
using AmigoOculto.Repository.Context;

namespace AmigoOculto.Repository.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AmigoOcultoContext context) : base(context)
        {
        }
    }
}
