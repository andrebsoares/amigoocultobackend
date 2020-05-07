using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmigoOculto.Domain.Interfaces.Repositories;
using AmigoOculto.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AmigoOculto.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly AmigoOcultoContext Db;
        protected readonly DbSet<T> DbSet;
        public RepositoryBase(AmigoOcultoContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }
        
        public async Task Add(T obj)
        {
            await DbSet.AddAsync(obj);
            await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var a = DbSet.ToList();
            //return DbSet;
            //Criando uma Task
            return await Task.Run(() =>
            {
                return DbSet;
            });
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            T entity = await GetById(id);
            await Task.Run(() =>
            {
                DbSet.Remove(entity);                
            });
            await Db.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {            
            await Task.Run(() =>
            {
                DbSet.Update(obj);                
            });
            await Db.SaveChangesAsync();
        }
    }
}
