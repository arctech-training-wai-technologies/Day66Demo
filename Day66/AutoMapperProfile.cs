using AutoMapper;
using Day66.Data.Dtos;
using Day66.Data.Models;

namespace Day66
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, FlightDto>().ReverseMap();
        }
    }
}
