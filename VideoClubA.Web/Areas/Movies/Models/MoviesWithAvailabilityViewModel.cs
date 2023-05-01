using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VideoClubA.Core.Enumerations;

namespace VideoClubA.Web.Areas.Movies.Models
{
    public class MoviesWithAvailabilityViewModel
    {
        public List<MovieWithAvailabilityViewModel> MoviesList {  get; set; }

        public List<string> MovieGenres { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string? SearchString { get; set; }

        public string? Filter { get; set; }


        public MoviesWithAvailabilityViewModel(List<MovieWithAvailabilityViewModel> moviesList, int currentPage,
                string searchString, string filter)
        {
            MoviesList = moviesList;
            MovieGenres = Enum.GetNames(typeof(MovieGenre)).ToList();
            CurrentPage = currentPage;
            SearchString = searchString;
            Filter = filter;

        }


    }
}
