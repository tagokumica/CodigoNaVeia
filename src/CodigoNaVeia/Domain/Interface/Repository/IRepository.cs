using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interface.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Insert(TEntity obj);
        TEntity FindbyId(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        int SaveChanges();
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

    }

}

