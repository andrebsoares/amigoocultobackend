using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmigoOculto.Service.Services
{
    public class ServiceBase<T> : IServiceBase<T>
    {
        private readonly IRepositoryBase<T> _repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public async Task Add(T obj)
        {
            await _repository.Add(obj);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Remove(int id)
        {
            await _repository.Remove(id);            
        }

        public async Task Update(T obj)
        {
            await _repository.Update(obj);
        }
    }
}
