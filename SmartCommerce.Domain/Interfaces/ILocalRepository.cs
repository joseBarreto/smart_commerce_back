using SmartCommerce.Domain.Entities;
using System.Collections.Generic;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILocalRepository : IBaseRepository<Local>
    {
        IList<Local> GetWithIncludes();
    }
}
