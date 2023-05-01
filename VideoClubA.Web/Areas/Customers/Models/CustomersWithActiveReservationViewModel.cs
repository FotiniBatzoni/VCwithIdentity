using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;

namespace VideoClubA.Web.Areas.Customers.Models
{
    public class CustomersWithActiveReservationViewModel
    {
        public List<CustomerActiveReservationsViewModel> CustomerList { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }


        public CustomersWithActiveReservationViewModel(List<CustomerActiveReservationsViewModel> customerList, int currentPage)
        {
            CustomerList = customerList;
            CurrentPage = currentPage;
        }


        private readonly ICustomerSevice _customerDb;
        private readonly IMovieRentService _movieRentDb;

        public CustomersWithActiveReservationViewModel(ICustomerSevice customerDb, IMovieRentService movieRentDb)
        {
            _customerDb = customerDb;
            _movieRentDb = movieRentDb;
        }
    }
}
