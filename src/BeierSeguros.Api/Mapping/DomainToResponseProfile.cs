using AutoMapper;
using BeierSeguros.Domain.CarWorkshops.Entities;
using BeierSeguros.Domain.CarWorkshops.ViewModels;
using BeierSeguros.Domain.CarWorkshopsInsurers.Entities;
using BeierSeguros.Domain.CarWorkshopsInsurers.ViewModels;
using BeierSeguros.Domain.Cities.Entities;
using BeierSeguros.Domain.Cities.ViewModels;
using BeierSeguros.Domain.InsurerAssistances.Entities;
using BeierSeguros.Domain.InsurerAssistances.ViewModels;
using BeierSeguros.Domain.Insurers.Entities;
using BeierSeguros.Domain.Insurers.ViewModels;
using BeierSeguros.Domain.Users.Entities;
using BeierSeguros.Domain.Users.ViewModels;

namespace BeierSeguros.Api.Mapping
{
    public class DomainToRequestProfile : Profile
    {
        public DomainToRequestProfile()
        {
            // CreateMap<City, CityResponse>()
            //     .ForMember(dest => dest.Tags, opt =>
            //         opt.MapFrom(src => src.Tags.Select(x => new TagResponse { Name = x.TagName })));

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserViewModel>();

            CreateMap<City, CityViewModel>();
            CreateMap<Insurer, InsurerViewModel>();
            CreateMap<InsurerAssistance, InsurerAssistanceViewModel>();

            CreateMap<CarWorkshop, CarWorkshopViewModel>()
                .ForMember(d => d.CityName, opt => opt.MapFrom(s => s.City.Name));

            CreateMap<CarWorkshopInsurer, CarWorkshopInsurerViewModel>()
                .ForMember(d => d.InsurerName, opt => opt.MapFrom(s => s.Insurer.Name));
        }
    }
}