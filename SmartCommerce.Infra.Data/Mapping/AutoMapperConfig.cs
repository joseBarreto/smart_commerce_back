using AutoMapper;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            var mapperConfiguration = new MapperConfiguration(config => {
                config.CreateMap<LoginModel,Login>();
            });

            var mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
