using FarmasiDemo.Entities.Concrete;
using FarmasiDemo.Entities.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using FarmasiDemo.DataAccessLayer.Context;
using FarmasiDemo.DataAccessLayer.Settings;

namespace FarmasiDemo.DataAccessLayer.Repository
{
    public class MongoDbRepositoryBase<T> : IRepository<T> where T : class,IEntity, new()
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<T> _collection;
        public MongoDbRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context=new MongoDbContext(settings);
            _collection = _context.GetCollection<T>();
        }
        public T Add(T entity)
        {
            try
            {
                _collection.InsertOne(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var delete = _collection.FindOneAndDeleteAsync(predicate);
                return delete;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            
            try
            {
                var result = _collection.AsQueryable().ToList();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetByIdAsync(string id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
                var result =  _collection.Find(filter).FirstOrDefault();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<T> UpdateAsync(ObjectId id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
