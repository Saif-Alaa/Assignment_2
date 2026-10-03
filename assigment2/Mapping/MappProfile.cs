using assigment2.Models;
using assigment2.Dtos;
using AutoMapper;

namespace assigment2.Mapping
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            CreateMap<Genre , GenreDto>();
            CreateMap<CreateGenreDto , Genre>();

            CreateMap<CreateCustomerDto ,Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CreateBookingDto, Booking>();
            CreateMap<Booking, BookingDto>();

            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieDto, Movie>();

            CreateMap<Booking, RevenueDto>();
        }
    }
}
