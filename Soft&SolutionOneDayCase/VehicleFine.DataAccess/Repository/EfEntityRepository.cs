using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VehicleFine.Entities.Abstract;

namespace VehicleFine.DataAccess.Repository
{
    public class EfEntityRepository<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        protected DbContext _entitiesContext;
        protected readonly DbSet<T> _dbSet;

        public EfEntityRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("EntitiesContext object is null");
            }
            this._entitiesContext = context;
            this._dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> All
        {
            get
            {
                try
                {
                    return GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
                return query.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = GetSingle(id);
                if (entity == null)
                {
                    return;
                }
                else
                {
                    Delete(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                EntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Edit(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _entitiesContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.AsEnumerable<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<T> GetAll(bool useNoTracking)
        {
            try
            {
                if (useNoTracking)
                {
                    return _dbSet.AsNoTracking<T>().AsEnumerable<T>();
                }
                else
                {
                    return GetAll();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            try
            {
                return _dbSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetAllAsQueryable(bool useNoTracking)
        {
            try
            {
                if (useNoTracking)
                {
                    return _dbSet.AsNoTracking<T>();
                }
                else
                {
                    return GetAllAsQueryable();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAllAsQueryable(string sql)
        {
            try
            {
                var results = _dbSet.FromSqlRaw<T>(sql, null).ToList();
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetSingle(int id)
        {
            try
            {
                return _dbSet.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Save()
        {
            try
            {
                _entitiesContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditRange(List<T> entity)
        {
            try
            {
                _entitiesContext.UpdateRange(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void AddRange(List<T> entity)
        {
            try
            {
                _dbSet.AddRange(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}