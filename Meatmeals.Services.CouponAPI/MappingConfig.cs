using AutoMapper;
using Meatmeals.Services.CouponAPI.Dtos;
using Meatmeals.Services.CouponAPI.Models;

namespace Meatmeals.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDto>();
                config.CreateMap<CouponDto, Coupon>();

            });

            return mappingConfig;
                


        }
    }
}
