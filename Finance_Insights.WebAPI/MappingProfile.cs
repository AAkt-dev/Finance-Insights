using AutoMapper;
using Finance_Insights.Entities.Models;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.WebAPI
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForUpdateDto, Account>().ReverseMap();
            CreateMap<AccountForCreationDto, Account>();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
