
using VideoClubA.Core.Entities;

namespace VideoClubA.Web.Areas.Reservations.Models
{
    public class DisplayReservationFormViewModel
    {
        public List<Movie> AllMovies ;

        public string CustomerId { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public DisplayReservationFormViewModel()
        {
            
        }

        public DisplayReservationFormViewModel(string customerId, List<Movie> allMovies, 
            string firstName, string lastName )
        {
            CustomerId = customerId;
            AllMovies = allMovies;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
