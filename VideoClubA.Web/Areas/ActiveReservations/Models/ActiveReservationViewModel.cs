using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VideoClubA.Web.Areas.ActiveReservations.Models
{
    public class ActiveReservationViewModel
    {
        [Display(Name = "Τίτλος Ταινίας")]
        public string MovieTitle { get; set; }

        [Display(Name = "Ημερομηνία Επιστροφής")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Σχόλια")]
        public string Comment { get; set; }

        [Display(Name = "Κόπια")]
        public string MovieCopyId { get; set;}

        [Display(Name = "Όνομα")]
        public string FirstName { get; set; }

        [Display(Name = "Επίθετο")]
        public string LastName { get; set; }

        public ActiveReservationViewModel()
        {
            
        }

        public ActiveReservationViewModel(string movieTitle, DateTime returnDate, string comment,
            string movieCopyid, string firstName, string lastName)
        {
            MovieTitle = movieTitle;
            ReturnDate = returnDate;
            Comment = comment;
            MovieCopyId = movieCopyid;
            FirstName = firstName;
            LastName = lastName;

        }
    }

    
}
