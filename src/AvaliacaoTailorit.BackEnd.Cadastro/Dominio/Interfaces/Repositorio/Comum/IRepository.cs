using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> Get(int id);

        Task<List<TEntity>> Get();

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<int> SaveChanges();
    }
}
