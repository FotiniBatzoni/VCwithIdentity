using System.ComponentModel.DataAnnotations;
using VideoClubA.Core.Entities;

namespace VideoClubA.Web.Areas.Reservations.Models
{
    public class CreateReservationBindingModel
    {

        public string CustomerId { get; set; }

        public string MovieId { get; set; }

        public string MovieTitle { get; set; }

        //public string SelectedMovie { get; set; }

        public string MovieCopyId { get; set; }
        public string Comment { get; set;}


        public CreateReservationBindingModel()
        {

        }

        public CreateReservationBindingModel( string movieCopyId, string customerId,  string comment, 
            string movieId, string movieTitle)
        {  

            CustomerId = customerId;
            Comment = comment;
            MovieCopyId = movieCopyId;
            MovieTitle = movieTitle;
            MovieId = movieId;
        }
    }


}
