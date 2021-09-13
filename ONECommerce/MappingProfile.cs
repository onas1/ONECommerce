using AutoMapper;
using ONECommerce.Models;
using ONECommerce.ViewModels;

namespace ONECommerce
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartViewModel>().ReverseMap();
        }
    }
}
