using iNUPCO.SHO.DTOs.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iNUPCO.SHO.Repo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string[]? includes = null);
        public IEnumerable<T> GetAll_Pagging(System.Linq.Expressions.Expression<Func<T, bool>> criteria, PagginationDTO paggination, out int recordsTotal, string[] includes = null);
        T Get(Expression<Func<T, bool>> criteria, string[]? includes = null);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
