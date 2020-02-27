using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
namespace InfraStructure.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> GetEntities();
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Delete(T entity);
    }
}
