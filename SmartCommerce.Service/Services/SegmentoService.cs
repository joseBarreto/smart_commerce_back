using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System.Collections.Generic;

namespace SmartCommerce.Service.Services
{
    public class SegmentoService : BaseService<Segmento>, ISegmentoService
    {
        public ISegmentoRepository _segmentoRepository { get; set; }

        public SegmentoService(ISegmentoRepository segmentoRepository) : base(segmentoRepository)
        {
            _segmentoRepository = segmentoRepository;
        }

        public IList<Segmento> GetWithIncludes(int pageNumber, int pageSize, out int totalRecords)
        {
            return _segmentoRepository.GetWithIncludes(pageNumber, pageSize, out totalRecords);
        }
    }
}