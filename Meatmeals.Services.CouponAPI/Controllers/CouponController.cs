using AutoMapper;
using Meatmeals.Services.CouponAPI.Database;
using Meatmeals.Services.CouponAPI.Dtos;
using Meatmeals.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Meatmeals.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {

        private readonly AppDbContext _db;
        private  CouponResponseDto _responseDto;
        private IMapper _mapper;
        public CouponController(AppDbContext db,IMapper mapper) {

            _db = db;
            _responseDto = new CouponResponseDto();
            _mapper = mapper;
        
        }


        [HttpGet]
        public CouponResponseDto GetCoupons()
        {

            try
            {

                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }

            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.isSuccess = false;
            }

            return _responseDto;
            
        }

        [HttpGet]
        [Route("{id:int}")]

        public CouponResponseDto GetCoupon(int id)
        {
            try
            {

                Coupon obj = _db.Coupons.First(r => (r.CouponId == id));

                _mapper.Map<CouponDto>(obj);

                _responseDto.Result = obj;
            }

            catch(Exception ex)
            {
                _responseDto.isSuccess=false;
                _responseDto.Message = ex.Message;
            }

            return _responseDto;

        }

        [HttpGet]
        [Route("GetByCode/{code}")]

        public CouponResponseDto GetCouponByCode(String code)
        {

            try
            {

               Coupon obj = _db.Coupons.FirstOrDefault(r => r.CouponCode.ToLower() == code.ToLower());

                _responseDto.Result = _mapper.Map<CouponDto>(obj);
            }

            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.isSuccess = false;
            }

            return _responseDto;
        }

        [HttpPost]
        public CouponResponseDto CreateCupon([FromBody] CouponDto req)
        {

            try
            {

                Coupon obj = _mapper.Map<Coupon>(req);

                _db.Coupons.Add(obj);

                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj); 

            }

            catch(Exception ex)
            {

                _responseDto.Message = ex.Message;
                _responseDto.isSuccess = false;
            }

            return _responseDto;
        }

        [HttpPut]
        public CouponResponseDto UpdateCoupon([FromBody] CouponDto req)
        {

            try
            {
                Coupon obj = _mapper.Map<Coupon>(req);

                _db.Coupons.Update(obj);

                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(obj);

            }

            catch(Exception ex)
            {

                _responseDto.Message = ex.Message;
                _responseDto.isSuccess = false;
            }

            return _responseDto;
        }

        [HttpDelete]
        public CouponResponseDto DeleteCoupon(int id)
        {
            try
            {

                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();

            }

            catch(Exception ex)
            {
                _responseDto.Message = ex.Message;
                _responseDto.isSuccess = false;
            }

            return _responseDto;

        }
    }
}
