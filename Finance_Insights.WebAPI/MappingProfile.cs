using AutoMapper;
using Finance_Insights.Entities.Models;
using Finance_Insights.Shared.DTOs;

namespace Finance_Insights.WebAPI
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountForUpdateDto, Account>();
            CreateMap<Account, AccountForUpdateDto>();
            CreateMap<AccountForCreationDto, Account>();
        }
    }
}
