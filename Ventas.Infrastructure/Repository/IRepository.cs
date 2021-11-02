
using Microsoft.EntityFrameworkCore.Query;
using Ventas.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ventas.Infrastructure.Repository
{
    public interface IRepository<T, U> where T : EntityBase<U>
    {
        T GetById(U id);
        IQueryable<T> List();
        IQueryable<T> List(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        int Delete(T entity);
        int Edit(T entity);
        Expression<Func<T, bool>> Criteria(T entyty);
        IIncludableQueryable<T, object> Include(Expression<Func<T, object>> entyty);
        List<string> IncludeStrings (string include);
    }
}