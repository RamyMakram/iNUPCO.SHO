using iNUPCO.SHO.Data.Context;
using iNUPCO.SHO.DTOs.Global;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace iNUPCO.SHO.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly iNUPCOContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(iNUPCOContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll(string[]? includes = null)
        {
            var qurable = entities.AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                    qurable.Include(include);

            return qurable.AsEnumerable();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> criteria, string[]? includes = null)
        {
            IQueryable<T> query = entities.AsQueryable();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return query.SingleOrDefault(criteria);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public IEnumerable<T> GetAll_Pagging(System.Linq.Expressions.Expression<Func<T, bool>> criteria, PagginationDTO paggination, out int recordsTotal, string[] includes = null)
        {
            var data = entities.Where(criteria).AsQueryable();

            if (includes != null)
                foreach (var incluse in includes)
                    data = data.Include(incluse);
            try
            {
                if (!string.IsNullOrEmpty(paggination.searchValue))
                {


                    if (paggination.searchColumn.Contains(","))
                    {

                        var searchcols = paggination.searchColumn.Split(',');
                        var searchConditions = "";
                        foreach (var searchcol in searchcols)
                        {
                            if (searchConditions != "")
                                searchConditions += " || ";
                            if (searchcol.Contains("@0"))
                                searchConditions += searchcol;
                            else
                                searchConditions += searchcol + ".Contains(@0)";
                        }

                        data = data.Where(searchConditions, paggination.searchValue);
                    }
                    else
                        data = data.Where(paggination.searchColumn + ".Contains(@0)", paggination.searchValue);
                }


            }
            catch (Exception dwdw)
            {

            }

            try
            {
                if (typeof(T).Name == "Project")
                {
                    data = data.OrderBy("ProjectLogs.OrderByDescending(Date).FirstOrDefault().Date DESC");
                }
            }
            catch (Exception ee)
            {

            }


            try
            {


                data = data.OrderBy(paggination.sortColumn + " " + paggination.sortColumnDirection.ToUpper());

            }
            catch (Exception eded)
            {

            }

            recordsTotal = data.Count();

            data = data.Skip(paggination.skip).Take(paggination.pageSize);



            return data;
        }
    }
}
