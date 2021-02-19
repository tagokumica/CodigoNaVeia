using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected CodigoNaVeiaContext codigoNaVeiaContext;
        protected DbSet<TEntity> DbSet;

        public Repository(CodigoNaVeiaContext context)
        {
            codigoNaVeiaContext = context;
            DbSet = codigoNaVeiaContext.Set<TEntity>();
        }

       

        public void Dispose()
        {
            codigoNaVeiaContext.Dispose();
            GC.SuppressFinalize(this);
        }

      

        public int SaveChanges()
        {
            return codigoNaVeiaContext.SaveChanges();
        }



        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }


        public TEntity Update(TEntity obj)
        {
            var entry = codigoNaVeiaContext.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity FindbyId(Guid id)
        {
            return DbSet.Find(id);
        }

        public TEntity Insert(TEntity obj)
        {
            return DbSet.Add(obj).Entity;
        }
    }
}