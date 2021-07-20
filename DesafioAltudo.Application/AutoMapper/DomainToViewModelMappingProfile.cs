using AutoMapper;
using DesafioAltudo.Application.Features.Pages;
using DesafioAltudo.Domain.Features;

namespace DesafioAltudo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PageViewModel, Page>();

        }


    }
}
