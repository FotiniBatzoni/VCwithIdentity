using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using VideoClubA.Core.Entities;

namespace VideoClubA.Web.Areas.Customers.Models
{
    public class CustomerActiveReservationsViewModel
    {
        public string CustomerId { get; set; }

        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }

        [Display(Name = "Επίθετο")]
        public string LastName { get; set; }

        [Display(Name = "Ενεργές Κρατήσεις")]
        public int ActiveReservations { get; set; }

        public CustomerActiveReservationsViewModel()
        {

        }

        public CustomerActiveReservationsViewModel(string customerId, string firstName, string lastName, int activeReservations)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            ActiveReservations = activeReservations;
        }
    }

  
}
