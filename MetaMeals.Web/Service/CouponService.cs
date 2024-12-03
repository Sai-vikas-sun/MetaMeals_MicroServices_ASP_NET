using MetaMeals.Web.Service.IService;
using MetaMeals.Web.Dtos;
using MetaMeals.Web.Utility;

namespace MetaMeals.Web.Service
{
    public class CouponService:ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetCouponByCodeAsync(string code)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                Url = StaticData.CouponAPIBase+"/api/coupon/GetByCode/code",


            });

        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await  _baseService.SendAsync(new RequestDto
            {
                Url = StaticData.CouponAPIBase+"/api/coupon",
                ApiType = StaticData.ApiType.GET


            });

        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {

            return  await _baseService.SendAsync(new RequestDto
            {
                Url = StaticData.CouponAPIBase + "/api/coupon/" +id,
                ApiType =StaticData.ApiType.GET

            });


        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupondto)
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticData.ApiType.POST,
                Url = StaticData.CouponAPIBase + "/api/coupon",
                Data = coupondto
            });


        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupondto)
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType=StaticData.ApiType.PUT,
                Url = StaticData.CouponAPIBase +"/api/coupon",
                Data = coupondto

            });


        }


        public async Task<ResponseDto?> DeleteCouponByIdAsync(int id)
        {

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticData.ApiType.DELETE,
                Url = StaticData.CouponAPIBase + "/api/coupon" + id
            });


        }

        
        



    }
}
