using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmigoOculto.Domain.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T obj);
        Task Update(T obj);
        Task Remove(int obj);        
    }
}
