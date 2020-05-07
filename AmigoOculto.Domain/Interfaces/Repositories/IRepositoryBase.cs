using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmigoOculto.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task Add(T obj);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(T obj);
        Task Remove(int id);
    }
}
