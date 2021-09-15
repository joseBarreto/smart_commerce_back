using AutoMapper;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Models;
using System.Linq;

namespace SmartCommerce.Infra.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Login, LoginModel>()
                .ForMember(dest => dest.DataUltimoAcesso, map => map.MapFrom(src => src.DataUltimoAcesso))
                .ForMember(dest => dest.DataCadastro, map => map.MapFrom(src => src.Usuario.DataCadastro))
                .ForMember(dest => dest.NomeCliente, map => map.MapFrom(src => src.Usuario.NomeCliente))
                .ForMember(dest => dest.Sobrenome, map => map.MapFrom(src => src.Usuario.Sobrenome))
                .ForMember(dest => dest.Empresa, map => map.MapFrom(src => src.Usuario.Empresa))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Usuario.Status));

            CreateMap<Local, LocalModel>()
                .ForMember(dest => dest.Produtos, map => map.MapFrom(src => src.LocalProdutos.Select(x => x.Produto)))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(src => src));

            CreateMap<Produto, ProdutoModel>();
            CreateMap<Segmento, SegmentoModel>();
            CreateMap<Local, EnderecoModel>();

        }
    }
}
