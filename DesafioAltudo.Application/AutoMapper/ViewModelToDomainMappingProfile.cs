using AutoMapper;
using DesafioAltudo.Application.Features.Pages;
using DesafioAltudo.Domain.Features;

namespace DesafioAltudo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Page, PageViewModel>();
        }
    }
}
