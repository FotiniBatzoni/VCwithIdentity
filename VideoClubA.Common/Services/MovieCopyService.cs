using Microsoft.EntityFrameworkCore;
using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;
using VideoClubA.Infrastucture.Data;

namespace VideoClubA.Common.Services
{
    public class MovieCopyService : IMovieCopyService
    {
        private readonly VideoClubDbContext _context;

        public MovieCopyService(VideoClubDbContext context)
        {
            _context = context;
        }
        public List<MovieCopy> GetAllAvailabiliy()
        {
            return _context.MovieCopies
                        .Where(moviecopies => moviecopies.IsAvailable == true)
                        .AsNoTracking()
                        .ToList();
        }

        public List<MovieCopy> GetAllUnAvailable()
        {
            return _context.MovieCopies
                .Where(moviecopies => moviecopies.IsAvailable == false)
                .AsNoTracking()
                .ToList();
        }

        public List<MovieCopy> GetAllMovieCopies()
        {
            return _context.MovieCopies
                        .AsNoTracking()
                        .ToList();
        }

        public List<MovieCopy> GetAvailableCopies(string movieId)
        {
            return _context.MovieCopies
                .Where(m => m.MovieId.Contains(movieId) && m.IsAvailable == true)
                .ToList();
        }

        public MovieCopy GetMovieCopy(string movieCopyId)
        {
            return _context.MovieCopies
                .Where(m => m.Id.Contains(movieCopyId))
                .FirstOrDefault(); ;
        }
    }
}
