using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;

namespace VideoClubA.Web.Areas.Reservations.Models
{
    public class RentsPerCustomerViewModel
    {
        public List<RentPerCustomerViewModel> ReservationsList { get; set; }

        public string CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public RentsPerCustomerViewModel(List<RentPerCustomerViewModel> reservationsList, int currentPage, 
            string customerId, string firstName, string lastName)
        {
            ReservationsList = reservationsList;
            CurrentPage = currentPage;
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}

