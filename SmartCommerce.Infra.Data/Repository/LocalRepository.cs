using Microsoft.EntityFrameworkCore;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SmartCommerce.Infra.Data.Repository
{
    public class LocalRepository : BaseRepository<Local>, ILocalRepository
    {
        public LocalRepository(SmartCommerceContext mySqlContext) : base(mySqlContext)
        {
        }

        public IList<Local> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords)
        {
            totalRecords = _myOracleContext.Set<Local>().Count();

            var locais = _myOracleContext.Local
                                    .Include(l => l.Usuario)
                                    .Include(l => l.Segmento)
                                    .Include(l => l.LocalProdutos)
                                        .ThenInclude(l => l.Produto)
                                    .OrderBy(x => x.Id)
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return locais;
        }
    }
}
