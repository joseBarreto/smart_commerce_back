using SmartCommerce.Domain.Entities;
using System.Collections.Generic;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ISegmentoService : IBaseService<Segmento>
    {
        IList<Segmento> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords);
    }
}