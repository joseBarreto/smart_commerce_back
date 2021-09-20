using AutoMapper;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Models;


namespace SmartCommerce.Infra.Data.Mapping
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddMaps(typeof(Program).Assembly);
            //});

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<LoginModel, Login>();
                config.CreateMap<Login, LoginModel>();
            });

            var mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
