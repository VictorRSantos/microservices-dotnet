using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using Microsoft.Extensions.Logging.Abstractions;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {  
        public static MapperConfiguration RegisterMaps()
        {           
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            }, NullLoggerFactory.Instance);
            return mappingConfig;
        }

    }
}
