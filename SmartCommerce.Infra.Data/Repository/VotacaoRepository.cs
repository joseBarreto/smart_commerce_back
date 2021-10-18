using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Infra.Data.Context;
using System;
using System.Linq;

namespace SmartCommerce.Infra.Data.Repository
{
    public class VotacaoRepository : BaseRepository<Votacao>, IVotacaoRepository
    {
        public VotacaoRepository(SmartCommerceContext mySqlContext) : base(mySqlContext)
        {
        }

        public Votacao GetByUsuarioIdAndLocalId(int usuarioId, int localId)
        {
            return _myOracleContext.Votacao.FirstOrDefault(x => x.UsuarioId == usuarioId && x.LocalId == localId);
        }

        public int GetCountByLocalId(int localId)
        {
            return _myOracleContext.Votacao.Count(x => x.LocalId == localId);
        }

        public bool Exists(int usuarioId, int localId)
        {
            return _myOracleContext.Votacao.Any(x => x.UsuarioId == usuarioId && x.LocalId == localId);
        }
    }
}
