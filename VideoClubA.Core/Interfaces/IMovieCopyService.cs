
using VideoClubA.Core.Entities;

namespace VideoClubA.Core.Interfaces
{

    public interface IMovieCopyService
    {
        public List<MovieCopy> GetAllAvailabiliy();

        public List<MovieCopy> GetAllUnAvailable();

        public List<MovieCopy> GetAvailableCopies(string movieId);

        public List<MovieCopy> GetAllMovieCopies();

        public MovieCopy GetMovieCopy(string movieCopyId);
    }
}
