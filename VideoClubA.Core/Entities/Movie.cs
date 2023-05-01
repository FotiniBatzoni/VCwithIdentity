
using System.ComponentModel.DataAnnotations;
using VideoClubA.Core.Enumerations;

namespace VideoClubA.Core.Entities
{
    public class Movie
    {
        public string Id { get; set; }
     
        public string Title { get; set; }

        public string Description { get; set; }

        public MovieGenre Genre { get; set; }
    }
}
