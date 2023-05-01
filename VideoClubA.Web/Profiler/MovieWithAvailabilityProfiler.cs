using AutoMapper;
using VideoClubA.Core.Entities;
using VideoClubA.Web.Areas.Movies.Models;
using VideoClubA.Web.Profiler;

namespace VideoClubA.Web.Profiler
{
    public class MovieWithAvailabilityProfiler : Profile
    {
        public MovieWithAvailabilityProfiler()
        {
            CreateMap<Movie, MovieWithAvailabilityViewModel>()
             .ForMember(dest => dest.Availability, opt => opt.MapFrom<MovieWithAvailabilityResolver>());
        }
    }
}
