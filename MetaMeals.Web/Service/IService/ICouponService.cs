using MetaMeals.Web.Dtos;

namespace MetaMeals.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponByCodeAsync(string code);
        Task<ResponseDto?> GetAllCouponsAsync();

        Task<ResponseDto?> GetCouponByIdAsync(int id);

        Task<ResponseDto?> CreateCouponAsync(CouponDto coupondto);

        Task<ResponseDto?> UpdateCouponAsync(CouponDto coupondto);

        Task<ResponseDto?> DeleteCouponByIdAsync(int id);


    }
}
