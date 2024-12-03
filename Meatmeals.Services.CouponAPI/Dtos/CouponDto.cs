using Microsoft.VisualBasic;

namespace Meatmeals.Services.CouponAPI.Dtos
{
    public class CouponDto
    {
        public int CouponId { get; set; }

        public String CouponCode { get; set; }

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
