using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meatmeals.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataToCouponTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "CouponCode", "CreatedDate", "DiscountAmount", "LastDate", "MinAmount" },
                values: new object[,]
                {
                    { 1, "15OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, "20OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150 },
                    { 3, "35OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { 4, "60OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500 },
                    { 5, "75OFF", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 540 }
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "CouponId",
                keyValue: 5);
        }
    }
}
