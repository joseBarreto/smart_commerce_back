using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System.Collections.Generic;

namespace SmartCommerce.Service.Services
{
    public class LocalService : BaseService<Local>, ILocalService
    {
        private ILocalRepository _localRepository { get; set; }
        private IVotacaoRepository _votacaoRepository { get; set; }

        public LocalService(ILocalRepository localRepository, IVotacaoRepository votacaoRepository) : base(localRepository)
        {
            _localRepository = localRepository;
            _votacaoRepository = votacaoRepository;
        }

        public override Local Add(Local obj)
        {
            obj.TotalVotacao = 1;
            var newLocal = base.Add(obj);

            var votacao = new Votacao()
            {
                LocalId = obj.Id,
                UsuarioId = obj.UsuarioId,
                Voto = true
            };

            _votacaoRepository.Insert(votacao);

            return newLocal;
        }

        public IList<Local> GetWithIncludes(int usuarioId, int pageNumber, int pageSize, out int totalRecords)
        {
            var listResult = _localRepository.GetWithIncludes(pageNumber, pageSize, out totalRecords);

            foreach (var item in listResult)
            {
                item.Votou = _votacaoRepository.Exists(usuarioId, item.Id);
            }

            return listResult;
        }
    }
}