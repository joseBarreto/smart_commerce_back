using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface IProdutoService : IBaseService<Produto>
    {
        Produto Add(Produto obj, int localId);
    }
}
