using System.ComponentModel.DataAnnotations;

namespace VideoClubA.Web.Areas.Reservations.Models
{
    public class RentPerCustomerViewModel
    {
        public string CustomerId { get; set; }

        [Display(Name ="Τίτλος Ταινίας")]
        public string MovieTitle { get; set; }

        [Display(Name = "Ημερομηνία Ενοικίασης")]
        public DateTime RentDate { get; set; }

        [Display(Name = "Ημερομηνία Επιστροφής")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Σχόλια")]
        public string Comment { get; set; }

        public RentPerCustomerViewModel()
        {
            
        }
        public RentPerCustomerViewModel(string customerId, string movieTitle, DateTime rentDate, DateTime returnDate, string comment )
        {
            CustomerId = customerId;
            MovieTitle = movieTitle;
            RentDate = rentDate; 
            ReturnDate = returnDate;
            Comment = comment;
        }
    }
}
