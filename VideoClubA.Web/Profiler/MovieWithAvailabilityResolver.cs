using AutoMapper;
using VideoClubA.Core.Entities;
using VideoClubA.Web.Areas.Movies.Models;

namespace VideoClubA.Web.Profiler
{
    public class MovieWithAvailabilityResolver : IValueResolver<Movie, MovieWithAvailabilityViewModel, int>
    {
        private Dictionary<string, int> _availabilityPerMovie;

        public MovieWithAvailabilityResolver(Dictionary<string, int> availabilityPerMovie)
        {
            _availabilityPerMovie = availabilityPerMovie;
        }

        public int Resolve(Movie source, MovieWithAvailabilityViewModel destination, int destMember, ResolutionContext context)
        {

            if (context.Items.TryGetValue("AvailabilityPerMovie", out object availabilityDictObj))
            {
                Dictionary<string, int> availabilityDict = (Dictionary<string, int>)availabilityDictObj;
                if (availabilityDict.ContainsKey(source.Id))
                {
                    return availabilityDict[source.Id];
                }
            }
            return 0;
        }
    }
}
