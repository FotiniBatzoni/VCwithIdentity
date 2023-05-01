using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VideoClubA.Core.Enumerations;

namespace VideoClubA.Web.Areas.Movies.Models
{
    public class MovieWithAvailabilityViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }


        [Display(Name = "Είδος ταινίας")]
        public MovieGenre Genre { get; set; }


        [Display(Name = "Διαθεσιμότητα")]
        public int Availability { get; set; }



        public MovieWithAvailabilityViewModel()
        {
            
        }

        public MovieWithAvailabilityViewModel(string id, string title, string description, MovieGenre genre, Dictionary<string, int> availabilityPerMovie)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            if (availabilityPerMovie.ContainsKey(id))
            {
                Availability = availabilityPerMovie[id];
            }
            else
            {
                Availability = 0;
            }

        }
    }
}
