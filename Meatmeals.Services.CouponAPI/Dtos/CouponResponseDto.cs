namespace Meatmeals.Services.CouponAPI.Dtos
{
    public class CouponResponseDto
    {
        public Object? Result { get; set; }

        public Boolean isSuccess { get; set; } = true;
        public String Message { get; set; } = "";
    }
}
