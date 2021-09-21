using SmartCommerce.Domain.Entities;
using System.Collections.Generic;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILocalService : IBaseService<Local>
    {
        IList<Local> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords);
    }
}