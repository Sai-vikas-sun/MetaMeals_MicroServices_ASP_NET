using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Meatmeals.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public String CouponCode { get; set; }

        [Required]
        public double DiscountAmount { get; set; }

        public int MinAmount {  get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastDate { get; set; }

    }
}
