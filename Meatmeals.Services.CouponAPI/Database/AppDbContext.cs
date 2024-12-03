using Meatmeals.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace Meatmeals.Services.CouponAPI.Database
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }

        

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "15OFF",
                DiscountAmount = 15,
                MinAmount = 100
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 150
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "35OFF",
                DiscountAmount = 35,
                MinAmount = 200
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 4,
                CouponCode = "60OFF",
                DiscountAmount = 60,
                MinAmount = 500
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 5,
                CouponCode = "75OFF",
                DiscountAmount = 70,
                MinAmount = 540
            });

            /*modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 6,
                CouponCode = "100OFF",
                DiscountAmount = 100,
                MinAmount = 570
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 7,
                CouponCode = "150OFF",
                DiscountAmount = 150,
                MinAmount = 600
            });*/
        }
    }
}
