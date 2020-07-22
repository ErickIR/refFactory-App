using CRD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CRD.InfraData.Context;

namespace CRD.InfraData.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        readonly DbSet<T> table;

        
        public BaseRepository(CooperaDBContext context)
        {
            table = context.Set<T>();
        }
        

        public void Create(T obj)
        {
            table.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return table.AsNoTracking().ToList();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).AsNoTracking();
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }
    }
}
