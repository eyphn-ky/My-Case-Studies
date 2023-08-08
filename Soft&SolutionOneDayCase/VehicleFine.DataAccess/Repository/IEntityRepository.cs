using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VehicleFine.Entities.Abstract;
using System.Text;
using System.Linq;

namespace VehicleFine.DataAccess.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IEnumerable<T> All { get; }
        IQueryable<T> GetAllAsQueryable();
        IQueryable<T> GetAllAsQueryable(bool useNoTracking);
        IEnumerable<T> GetAllAsQueryable(string sql);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(bool useNoTracking);
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetSingle(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void EditRange(List<T> entity);
        void AddRange(List<T> entity);
    }

}