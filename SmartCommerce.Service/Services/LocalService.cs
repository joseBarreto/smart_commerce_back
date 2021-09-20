using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System.Collections.Generic;

namespace SmartCommerce.Service.Services
{
    public class LocalService : BaseService<Local>, ILocalService
    {
        public ILocalRepository _localRepository { get; set; }

        public LocalService(ILocalRepository localRepository) : base(localRepository)
        {
            _localRepository = localRepository;
        }

        public IList<Local> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords)
        {
            return _localRepository.GetWithIncludes(pageNumber, pageSize, out totalRecords);
        }
    }
}
