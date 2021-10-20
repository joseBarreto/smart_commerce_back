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

            CreateMap<Local, LocalSimpleModel>()
                .ForMember(dest => dest.Endereco, map => map.MapFrom(src => src))
                .ForMember(dest => dest.ImageURL, map => map.MapFrom(src => src.ImagemURL));

            CreateMap<LocalSimpleModel, Local>()
               .ForMember(dest => dest.ImagemURL, map => map.MapFrom(src => src.ImageURL))
               //.ForMember(dest => dest, map => map.MapFrom(src => src.Endereco));
               .ForMember(dest => dest.Bairro, map => map.MapFrom(src => src.Endereco.Bairro))
               .ForMember(dest => dest.Cep, map => map.MapFrom(src => src.Endereco.Cep))
               .ForMember(dest => dest.Cidade, map => map.MapFrom(src => src.Endereco.Cidade))
               .ForMember(dest => dest.Complemento, map => map.MapFrom(src => src.Endereco.Complemento))
               .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Endereco.Latitude))
               .ForMember(dest => dest.Logradouro, map => map.MapFrom(src => src.Endereco.Logradouro))
               .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Endereco.Longitude))
               .ForMember(dest => dest.Numero, map => map.MapFrom(src => src.Endereco.Numero))
               .ForMember(dest => dest.Uf, map => map.MapFrom(src => src.Endereco.Uf));

            CreateMap<Produto, ProdutoModel>();
            CreateMap<ProdutoModel, Produto>();

            CreateMap<Segmento, SegmentoModel>();
            CreateMap<Local, EnderecoModel>();
            CreateMap<EnderecoModel, Local>();



        }
    }
}