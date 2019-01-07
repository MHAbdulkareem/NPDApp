using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.DataAccess
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetByID(object ID);
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
    }
}
