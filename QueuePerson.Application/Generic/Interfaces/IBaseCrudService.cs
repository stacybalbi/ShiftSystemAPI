using QueuePerson.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuePerson.Application.Generic.Interfaces
{
    public interface IBaseCrudService<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Query();
        Task<List<TEntity>> Get(int top = 50);
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
