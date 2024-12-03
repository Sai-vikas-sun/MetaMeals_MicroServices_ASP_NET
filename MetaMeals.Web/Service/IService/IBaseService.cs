using MetaMeals.Web.Dtos;

namespace MetaMeals.Web.Service.IService
{
    public interface IBaseService
    {

        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
