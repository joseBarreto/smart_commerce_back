using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;

namespace SmartCommerce.Service.Services
{
    public class VotacaoService : BaseService<Votacao>, IVotacaoService
    {
        private IVotacaoRepository _votacaoRepository { get; set; }
        private ILocalRepository _localRepository { get; set; }

        public VotacaoService(IVotacaoRepository baseRepository, ILocalRepository localRepository) : base(baseRepository)
        {
            _votacaoRepository = baseRepository;
            _localRepository = localRepository;
        }

        public void Votar(Votacao votacao)
        {
            var votacaoAtual = _votacaoRepository.GetByUsuarioIdAndLocalId(votacao.UsuarioId, votacao.LocalId);
            if (votacaoAtual != null)
            {
                votacaoAtual.Voto = votacao.Voto;
                _votacaoRepository.Update(votacaoAtual);
            }
            else
            {
                _votacaoRepository.Insert(votacao);
            }

            var totalVotacoes = _votacaoRepository.GetCountByLocalId(votacao.LocalId);
            _localRepository.UpdateTotalVotacao(votacao.LocalId, totalVotacoes);

        }


    }
}
