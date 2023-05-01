using VideoClubA.Core.Interfaces;
using VideoClubA.Infrastucture.Data;
using VideoClubA.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace VideoClubA.Common.Services
{
    public class MovieRentService : IMovieRentService
    {
        private  VideoClubDbContext _context;

        public MovieRentService(VideoClubDbContext context)
        {
            _context = context;
        }

        public List<MovieRent> GetMovieRents()
        {
            return _context.MovieRents
                .Include(m => m.Customer)
                .Include(m => m.Movie)
                .Include(m => m.MovieCopy)
                .Where(mr => mr.ReturnDate > DateTime.Now)
                //.AsNoTracking()
                .ToList();

        }

        public List<MovieRent> GetRentsPerCustomer(string customerId)
        {
            List<MovieRent> movieRents = GetMovieRents();

            var rents = movieRents
                .Where(m => m.CustomerId.Contains(customerId))
                    .Select(m => new MovieRent
                    {
                        CustomerId = m.Id,
                        MovieTitle = m.MovieTitle,
                        RentDate = m.RentDate,
                        ReturnDate = m.ReturnDate,
                        Comment = m.Comment
                    })
                    .ToList();

            return rents;
        }

        public void CreateReservation(MovieRent movieRent)
        {
            _context.MovieRents.Add(movieRent);
            _context.SaveChanges();
        }
    }
}




