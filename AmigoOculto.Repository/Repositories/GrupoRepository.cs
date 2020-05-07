using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Models;
using AmigoOculto.Repository.Context;

namespace AmigoOculto.Repository.Repositories
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupoRepository
    {
        public GrupoRepository(AmigoOcultoContext context) : base(context)
        {
        }
    }
}
