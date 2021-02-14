using api.DTOs;
using api.Entities;
using AutoMapper;

namespace api.Contracts
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Activity, ActivityDto>();
            CreateMap<Activity, ActivitiesDto>();
            CreateMap<Booking, PrivateBookingsDto>();
        }
    }
}