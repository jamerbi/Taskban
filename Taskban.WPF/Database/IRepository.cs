using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Taskban.WPF.Database
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> orderBy = null, bool ascending = true);
        TEntity GetById(object id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
    }
}