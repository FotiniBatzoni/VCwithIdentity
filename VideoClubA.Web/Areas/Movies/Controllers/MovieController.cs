using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoClubA.Core.Entities;
using VideoClubA.Core.Interfaces;
using VideoClubA.Web.Areas.Movies.Models;

namespace VideoClubA.Web.Areas.Movies.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieService _movieDb;
        private readonly IMovieCopyService _movieCopyDb;
        private readonly ILogger _logger;

        public MovieController(IMapper mapper, IMovieService movieDb, IMovieCopyService movieCopyDb,
            ILogger<MovieController> logger)
        {
            _mapper = mapper;
            _movieDb = movieDb;
            _movieCopyDb = movieCopyDb;
            _logger = logger;
        }

        [HttpGet]
        [Area("Movies")]
        public ActionResult MovieGallery(int page = 1, int pageSize = 5, string searchString = "", string filter = "")
        {
    
           return View(PaginateMovies(page, pageSize, searchString, filter));
         
        }

        private Dictionary<string, int> GetAllAvailabilityPerMovie()
        {
            List<MovieCopy> availableMoviesCopies = _movieCopyDb.GetAllAvailabiliy();

            var movieCopyIds = availableMoviesCopies.GroupBy(c => c.MovieId);

            var result = movieCopyIds.ToDictionary(g => g.Key, g => g.Count());

            return result;
        }

        private MoviesWithAvailabilityViewModel PaginateMovies(int page, int pageSize,
             string searchString,  string filter)
        {

            //Validate Page
            page = Math.Clamp(page, 1, pageSize);

            int startIndex = (int)((page - 1) * pageSize);

            List<Movie> movies = _movieDb.GetAllMovies();

            Dictionary<string, int> availabilityPerMovie = GetAllAvailabilityPerMovie();

            int totalPages = (int)Math.Ceiling((double)movies.Count / pageSize);

            var moviesList = _mapper.Map<List<MovieWithAvailabilityViewModel>>
                (movies.OrderBy(m => m.Title), opt => opt.Items["AvailabilityPerMovie"] = availabilityPerMovie);

            List<MovieWithAvailabilityViewModel> movieResults;


            if (!string.IsNullOrEmpty(searchString))
            {
                //Search
                movieResults = moviesList.Where(s => s.Title.Contains(searchString)).ToList();
            }
            else if (!string.IsNullOrEmpty(filter))
            {
                //Filter
                movieResults = moviesList.Where(s => s.Genre.ToString().Equals(filter)).ToList();
            }
            else
            {
                movieResults = moviesList;
            }

            movieResults = movieResults.Skip(startIndex).Take(pageSize).ToList();

            var moviesViewModel = new MoviesWithAvailabilityViewModel(
                movieResults.ToList(),page,searchString,filter);


            moviesViewModel.CurrentPage = page;
            moviesViewModel.TotalPages = totalPages;
            moviesViewModel.SearchString = searchString;
            moviesViewModel.Filter = filter;

            return moviesViewModel;
        }


    }
}
