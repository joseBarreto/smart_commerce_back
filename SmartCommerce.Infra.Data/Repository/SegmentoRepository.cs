using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SmartCommerce.Infra.Data.Repository
{
    public class SegmentoRepository : BaseRepository<Segmento>, ISegmentoRepository
    {
        public SegmentoRepository(SmartCommerceContext mySqlContext) : base(mySqlContext)
        {
        }

        public IList<Segmento> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords)
        {
            totalRecords = _myOracleContext.Set<Segmento>().Count();

            var segmentos = _myOracleContext.Segmento
                                    .OrderBy(x => x.Id)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return segmentos;
        }
    }
}