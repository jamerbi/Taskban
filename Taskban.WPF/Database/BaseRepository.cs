using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Taskban.WPF.Database
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ILiteCollection<TEntity> _collection;

        public BaseRepository(ILiteDatabase database, string collection)
        {
            _collection = database.GetCollection<TEntity>(collection);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool ascending = true)
        {
            var query = _collection.Query();

            if (filter != null)
            {
                query.Where(filter);
            }

            if (orderBy != null)
            {
                if (ascending)
                {
                    query.OrderBy(orderBy);
                }
                else
                {
                    query.OrderByDescending(orderBy);
                }
            }

            return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return _collection.FindOne($"$._id = {id}");
        }

        public TEntity Insert(TEntity entity)
        {
            var result = _collection.Insert(entity);
            return GetById(result);
        }

        public void Update(TEntity entity)
        {
            _collection.Update(entity);
        }

        public void Delete(object id)
        {
            _collection.Delete((int) id);
        }
    }
}