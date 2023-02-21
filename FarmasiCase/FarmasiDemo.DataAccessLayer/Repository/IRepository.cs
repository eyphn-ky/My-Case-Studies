using FarmasiDemo.Entities.Interface;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        T GetByIdAsync(string id);
        T Add(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(ObjectId id, T entity);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(ObjectId id);
        Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
