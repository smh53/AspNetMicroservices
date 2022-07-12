using AutoMapper;
using Discount.Grpc.Entities;
using Discout.Grpc.Protos;

namespace Discout.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
