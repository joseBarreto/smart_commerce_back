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

            CreateMap<Login, LoginCreateModel>()
                .ForMember(dest => dest.Nome, map => map.MapFrom(src => src.Usuario.NomeCliente))
                .ForMember(dest => dest.Sobrenome, map => map.MapFrom(src => src.Usuario.Sobrenome));

            CreateMap<LoginCreateModel, Usuario>()
              .ForMember(dest => dest.NomeCliente, map => map.MapFrom(src => src.Nome))
              .ForMember(dest => dest.Sobrenome, map => map.MapFrom(src => src.Sobrenome));

            CreateMap<LoginCreateModel, Login>()
                .ForMember(dest => dest.Usuario, map => map.MapFrom(src => src));

            CreateMap<Local, LocalModel>()
                .ForMember(dest => dest.Produtos, map => map.MapFrom(src => src.LocalProdutos.Select(x => x.Produto)))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(src => src))
                .ForMember(dest => dest.ImageURL, map => map.MapFrom(src => src.ImagemURL));

            CreateMap<Produto, ProdutoModel>();
            CreateMap<Segmento, SegmentoModel>();
            CreateMap<Local, EnderecoModel>();



        }
    }
}