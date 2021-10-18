using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface IVotacaoService : IBaseService<Votacao>
    {
        void Votar(Votacao votacao);
    }
}
