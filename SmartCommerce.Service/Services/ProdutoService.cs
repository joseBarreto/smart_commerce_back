using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCommerce.Service.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private IBaseRepository<Produto> _produtoRepository { get; set; }
        private IBaseRepository<LocalProduto> _localProdutoRepository { get; set; }

        public ProdutoService(IBaseRepository<Produto> produtoRepository, IBaseRepository<LocalProduto> localProdutoRepository) : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _localProdutoRepository = localProdutoRepository;
        }

        public Produto Add(Produto obj, int localId)
        {
            var localProduto = new LocalProduto()
            {
                Produto = obj,
                LocalId = localId
            };

            _localProdutoRepository.Insert(localProduto);
            return obj;
        }
    }
}
