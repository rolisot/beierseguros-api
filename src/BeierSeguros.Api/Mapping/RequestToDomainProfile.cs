using AutoMapper;
using BeierSeguros.Domain.CarWorkshops.Commands;
using BeierSeguros.Domain.CarWorkshops.ViewModels;
using BeierSeguros.Domain.Cities.Commands;
using BeierSeguros.Domain.Cities.ViewModels;
using BeierSeguros.Domain.Core;
using BeierSeguros.Domain.Insurers.Commands;
using BeierSeguros.Domain.Insurers.ViewModels;
using BeierSeguros.Domain.Users.Commands;
using BeierSeguros.Domain.Users.ViewModels;

namespace BeierSeguros.Api.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<CreateUserViewModel, CreateUserCommand>();

            CreateMap<CreateCityViewModel, CreateCityCommand>();
            CreateMap<UpdateCityViewModel, UpdateCityCommand>();
            CreateMap<DeleteCityViewModel, DeleteCityCommand>();

            CreateMap<CreateInsurerViewModel, CreateInsurerCommand>();
            CreateMap<UpdateInsurerViewModel, UpdateInsurerCommand>();
            CreateMap<DeleteInsurerViewModel, DeleteInsurerCommand>();

            CreateMap<CreateCarWorkshopViewModel, CreateCarWorkshopCommand>();
            CreateMap<UpdateCarWorkshopViewModel, UpdateCarWorkshopCommand>();
            CreateMap<DeleteCarWorkshopViewModel, DeleteCarWorkshopCommand>();
        }
    }
}