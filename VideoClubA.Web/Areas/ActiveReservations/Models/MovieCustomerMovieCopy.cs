using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;
using VideoClubA.Web.Areas.ActiveReservations.Models;
using VideoClubA.Web.Areas.Customers.Models;

namespace VideoClubA.Web.Areas.ActiveReservations.Models
{
    public class MovieCustomerMovieCopy
    {
        private readonly IMovieRentService _movieRentDb;
        private readonly ICustomerSevice _customerDb;
        private readonly IMovieCopyService _movieCopyDb;

        public MovieCustomerMovieCopy(IMovieRentService movieRentDb, 
            ICustomerSevice customerDb, IMovieCopyService movieCopyDb)
        {
            _movieRentDb = movieRentDb;
            _customerDb = customerDb;
            _movieCopyDb = movieCopyDb;
        }

        public List<ActiveReservationViewModel> Get()
        {
            List<MovieRent> movieRents = _movieRentDb.GetMovieRents();
            List<Customer> customers = _customerDb.GetAllCustomers();
            List<MovieCopy> movieCopies = _movieCopyDb.GetAllUnAvailable();

            var activeReservations = movieRents
            .Join(customers,
                mr => mr.CustomerId,
                c => c.Id,
                (mr, c) => new { MovieRent = mr, Customer = c })
            .Join(movieCopies,
                x => x.MovieRent.MovieCopyId,
                mc => mc.Id,
                (x, mc) => new ActiveReservationViewModel
                {
                    MovieTitle = x.MovieRent.MovieTitle,
                    MovieCopyId = x.MovieRent.MovieCopyId,
                    FirstName = x.Customer.FirstName,
                    LastName = x.Customer.LastName,
                    ReturnDate = x.MovieRent.ReturnDate,
                    Comment = x.MovieRent.Comment
                })
            .ToList();


            Console.WriteLine( activeReservations);

            return activeReservations;
        }
    }
}


//movieRents
//                .Where(mr => !mr.MovieCopy.IsAvailable && mr.ReturnDate > DateTime.Now)
//               .Where(mr => mr.MovieCopyId != null)
//               .Select(mr => new ActiveReservationViewModel
//               {
//                   MovieTitle = mr.MovieTitle,
//                   ReturnDate = mr.ReturnDate,
//                   Comment = mr.Comment,
//                   MovieCopyId = mr.MovieCopy.Id,
//                   FirstName = mr.Customer.FirstName,
//                   LastName = mr.Customer.LastName
//               }).ToList();