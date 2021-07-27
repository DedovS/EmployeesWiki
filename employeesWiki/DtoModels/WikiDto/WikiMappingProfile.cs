using AutoMapper;
using employeesWiki.Models;

namespace employeesWiki.DtoModels.WikiDto
{
    public class WikiMappingProfile : Profile
    {
        public WikiMappingProfile()
        {
            CreateMap<Wiki, WikiDto>();
            CreateMap<WikiDto, Wiki>();
        }
    }
}