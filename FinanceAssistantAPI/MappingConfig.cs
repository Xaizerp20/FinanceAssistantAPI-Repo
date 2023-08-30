using AutoMapper;
using FinanceAssistantAPI.Models;
using FinanceAssistantAPI.Models.Dto;

namespace WEBTEST_API_PROYECT
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<ApplicationFinancialRecord, ApplicationFinancialRecordDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserCreateDto>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserUpdateDto>().ReverseMap();
        }
    }
}
