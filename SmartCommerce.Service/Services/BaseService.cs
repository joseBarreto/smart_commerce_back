using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System.Collections.Generic;

namespace SmartCommerce.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add(TEntity obj)
        {
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IList<TEntity> Get(int pageNumber, int pageSize, out int totalRecords)
        {
            totalRecords = _baseRepository.TotalRecords();
            return _baseRepository.Select(pageNumber, pageSize);
        }

        public TEntity GetById(int id)
        {
            return _baseRepository.Select(id);
        }

        public TEntity Update(TEntity obj)
        {
            _baseRepository.Update(obj);
            return obj;
        }
    }
}
