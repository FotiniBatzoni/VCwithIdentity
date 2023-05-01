using AutoMapper;
using VideoClubA.Core.Entities;
using VideoClubA.Web.Areas.Reservations.Models;

namespace VideoClubA.Web.Profiler
{
    public class MovieRentsPerCustomerProfiler : Profile
    {
        public MovieRentsPerCustomerProfiler()
        {
            CreateMap<MovieRent, RentPerCustomerViewModel>();
            CreateMap<List<MovieRent>, RentsPerCustomerViewModel>()
                .ForMember(dest => dest.ReservationsList, opt => opt.MapFrom(src => src));
        }
       
    }
}
