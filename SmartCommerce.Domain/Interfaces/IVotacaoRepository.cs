using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface IVotacaoRepository : IBaseRepository<Votacao>
    {

        Votacao GetByUsuarioIdAndLocalId(int usuarioId, int localId);

        int GetCountByLocalId(int localId);

        bool Exists(int usuarioId, int localId);
    }
}
