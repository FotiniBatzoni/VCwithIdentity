using AutoMapper;
using VideoClubA.Core.Entities;
using VideoClubA.Web.Areas.ActiveReservations.Models;

namespace VideoClubA.Web.Profiler
{
    public class ActiveReservationsProfiler :Profile
    {
        public ActiveReservationsProfiler()
        {
            CreateMap<MovieRent, ActiveReservationViewModel>()
                        .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.MovieTitle))
                        .ForMember(dest => dest.MovieCopyId, opt => opt.MapFrom(src => src.MovieCopyId))
                        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Customer.LastName))
                        .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate))
                        .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

        }
    }
}
