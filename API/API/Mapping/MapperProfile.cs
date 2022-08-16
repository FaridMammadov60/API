using API.Dtos.CategoryDtos;
using API.Dtos.ProductDtos;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryReturnDto>()
                .ForMember(d=>d.ImageUrl,map=>map.MapFrom(s=> "https://localhost:44369/"+s.ImageUrl))
                .ForMember(d=>d.ProductCount, map=>map.MapFrom(s=>s.Products.Count));

            CreateMap<Category, ProductCategoryDto>().ReverseMap();

            CreateMap<Product, ProductReturnDto>().ReverseMap();

        }
    }
}
