using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;

namespace VideoClubA.Web.Areas.Customers.Models
{
    public class MovieRentCustomer
    {

        private readonly ICustomerSevice _customerDb;
        private readonly IMovieRentService _movieRentDb;

        public MovieRentCustomer(ICustomerSevice customerDb, IMovieRentService movieRentDb)
        {
            _customerDb = customerDb;
            _movieRentDb = movieRentDb;
        }

        public List<CustomerActiveReservationsViewModel> Get()
        {
            List<Customer> customers = _customerDb.GetAllCustomers();
            List<MovieRent> movieRents = _movieRentDb.GetMovieRents();

                var customersWithReservations = customers
                    .GroupJoin(
                       movieRents.Where(mr => mr.ReturnDate > DateTime.Now),
                        c => c.Id,
                        mr => mr.CustomerId,
                        (c, mr) => new { Customer = c, MovieRent = mr })
                    .SelectMany(
                        x => x.MovieRent.DefaultIfEmpty(),
                        (x, mr) => new { Customer = x.Customer, MovieRent = mr })
                    .GroupBy(
                        x => new { x.Customer.Id, x.Customer.FirstName, x.Customer.LastName },
                        x => x.MovieRent)
                    .Select(
                        g => new CustomerActiveReservationsViewModel
                        {
                            CustomerId = g.Key.Id,
                            FirstName = g.Key.FirstName,
                            LastName = g.Key.LastName,
                            ActiveReservations = g.Count(mr => mr != null)
                        })
                    .OrderByDescending(x => x.ActiveReservations)
                    .ToList();

            return customersWithReservations;


        }
    }
}
