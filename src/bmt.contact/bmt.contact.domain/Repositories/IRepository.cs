using bmt.contact.domain.Entities;
using bmt.contact.domain.ValueObjects;
using bmt.shared.abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmt.contact.domain.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : AggregateRoot<TId>
    {
        Task<TEntity> GetByIdAsync(TId id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TId id);
    }
}
