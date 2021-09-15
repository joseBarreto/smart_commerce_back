using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SmartCommerce.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SmartCommerceContext _myOracleContext;

        public BaseRepository(SmartCommerceContext mySqlContext)
        {
            _myOracleContext = mySqlContext;
        }


        public void Insert(TEntity obj)
        {
            _myOracleContext.Set<TEntity>().Add(obj);
            _myOracleContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _myOracleContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _myOracleContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _myOracleContext.Set<TEntity>().Remove(Select(id));
            _myOracleContext.SaveChanges();
        }

        public IList<TEntity> Select(int pageNumber, int pageSize)
        {
            return _myOracleContext.Set<TEntity>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        }

        public TEntity Select(int id) => _myOracleContext.Set<TEntity>().Find(id);

        public int TotalRecords() => _myOracleContext.Set<TEntity>().Count();
    }
}
